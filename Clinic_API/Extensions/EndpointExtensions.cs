using Clinic2026_API.Data;
using Clinic2026_API.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Clinic2026_API.Extensions;

/// <summary>
/// Extension methods for mapping API endpoints
/// </summary>
public static class EndpointExtensions
{
    /// <summary>
    /// Map all entity endpoints using reflection
    /// </summary>
    public static WebApplication MapAllEntityEndpoints(this WebApplication app)
    {
        var dbContextType = typeof(ClinicDbContext);
        var dbSetProperties = dbContextType.GetProperties()
            .Where(p => p.PropertyType.IsGenericType &&
                        p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

        foreach (var property in dbSetProperties)
        {
            var entityType = property.PropertyType.GetGenericArguments()[0];
            var entityName = entityType.Name;
            var routeName = property.Name.ToLower();

            // Determine category and route prefix
            var (category, routePrefix) = GetCategoryAndPrefix(entityName);

            // Use reflection to call generic method
            var method = typeof(EndpointExtensions)
                .GetMethod(nameof(MapGenericEndpoint), BindingFlags.NonPublic | BindingFlags.Static)
                ?.MakeGenericMethod(entityType);

            method?.Invoke(null, new object[] { app, routePrefix, routeName, category });
        }

        return app;
    }

    /// <summary>
    /// Get category and route prefix based on entity name
    /// </summary>
    private static (string Category, string RoutePrefix) GetCategoryAndPrefix(string entityName)
    {
        if (entityName.StartsWith("Fin")) return ("Finance", "finance");
        if (entityName.StartsWith("Lt")) return ("Lookup", "lookup");
        if (entityName.StartsWith("Inv")) return ("Inventory", "inventory");
        if (entityName.StartsWith("Sm")) return ("System", "system");

        if (entityName == "TblUser" || entityName == "TblRole" || entityName == "TblUserRole")
            return ("System", "system");
        if (entityName.StartsWith("Str")) return ("Structure", "structure");
        if (entityName.StartsWith("View")) return ("View", "view");
        if (entityName.StartsWith("Time")) return ("TimeAttendance", "time-attendance");

        return ("Entities", "entities");
    }

    /// <summary>
    /// Map a generic GET endpoint for an entity type
    /// </summary>
    private static void MapGenericEndpoint<T>(
        WebApplication app,
        string routePrefix,
        string routeName,
        string category) where T : class
    {
        var endpoint = app.MapGet($"/api/{routePrefix}/{routeName}", async (
            ClinicDbContext db,
            HttpRequest request,
            ILogger<T> logger,
            string? search = null,
            string? sort = null,
            string? order = null,
            int? page = 1,
            int? pageSize = 50) =>
        {
            try
            {
                // Ensure valid page and pageSize
                int pageNumber = page ?? 1;
                int size = pageSize ?? 50;
                if (pageNumber < 1) pageNumber = 1;
                if (size < 1) size = 50;
                if (size > 1000) size = 1000; // Cap page size

                var query = db.Set<T>().AsQueryable();

                // Apply search
                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = QueryService.ApplySearch(query, search);
                }

                // Apply filters
                query = QueryService.ApplyFilters(query, request.Query);

                // Apply sort
                query = QueryService.ApplySort(query, sort, order);

                // Get total count
                var totalCount = await query.CountAsync();

                // Apply pagination
                var items = await query
                    .Skip((pageNumber - 1) * size)
                    .Take(size)
                    .ToListAsync();

                // Create result object
                var result = new
                {
                    Items = items,
                    TotalCount = totalCount,
                    Page = pageNumber,
                    PageSize = size,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)size)
                };

                return Results.Ok(result);
            }
            catch (DbUpdateException ex)
            {
                logger.LogError(ex, "Database error while fetching {EntityType}", typeof(T).Name);
                throw new Exceptions.DatabaseException($"fetching", typeof(T).Name, ex);
            }
            catch (InvalidOperationException ex)
            {
                logger.LogError(ex, "Invalid operation while processing {EntityType}", typeof(T).Name);
                throw new Exceptions.CustomException(
                    $"Invalid operation: {ex.Message}",
                    400,
                    "INVALID_OPERATION",
                    innerException: ex);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unexpected error while fetching {EntityType}", typeof(T).Name);
                throw new Exceptions.CustomException(
                    $"Unexpected error: {ex.Message}",
                    500,
                    "INTERNAL_ERROR",
                    innerException: ex);
            }
        });

        // Apply Output Caching Policy
        if (category == "Lookup")
        {
            // Apply 365-day expiration and tag with Entity Name for eviction
            endpoint.CacheOutput(x => x.Expire(TimeSpan.FromDays(365)).Tag(typeof(T).Name));
        }
        else
        {
            // Default Policy - Cache for 5 mins but TAG it for eviction
            endpoint.CacheOutput(x => x.Tag(typeof(T).Name));
        }

        endpoint.WithTags(category)
        .WithName($"Get_{routeName}")
        .WithOpenApi(operation =>
        {
            operation.Summary = $"Get all {routeName}";
            operation.Description = $"Retrieve all {routeName} with optional filtering, searching, and sorting.";

            // Add filter parameters for each property
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                var propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                string schemaType = propType.Name switch
                {
                    "Int32" or "Int64" or "Int16" => "integer",
                    "Double" or "Single" or "Decimal" => "number",
                    "Boolean" => "boolean",
                    "DateTime" => "string",
                    _ => "string"
                };

                // Skip if parameter already exists (case-insensitive check)
                if (operation.Parameters.Any(p => p.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }

                // Skip generic params handled by route
                // checking specific names that are arguments in the delegate
                var knownParams = new[] { "search", "sort", "order", "page", "pageSize" };
                if (knownParams.Contains(prop.Name, StringComparer.OrdinalIgnoreCase)) continue;

                operation.Parameters.Add(new Microsoft.OpenApi.Models.OpenApiParameter
                {
                    Name = prop.Name,
                    In = Microsoft.OpenApi.Models.ParameterLocation.Query,
                    Description = $"Filter by {prop.Name}",
                    Required = false,
                    Schema = new Microsoft.OpenApi.Models.OpenApiSchema
                    {
                        Type = schemaType,
                        Format = propType.Name == "DateTime" ? "date-time" : null
                    }
                });
            }

            return operation;
        });
    }
}
