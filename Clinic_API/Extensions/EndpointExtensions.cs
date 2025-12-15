using Clinic2026_API.Data;
using Clinic2026_API.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Clinic2026_API.Models.Entities;
using Microsoft.AspNetCore.OutputCaching;
using System.Net;

namespace Clinic2026_API.Extensions;

/// <summary>
/// Extension methods for mapping API endpoints
/// </summary>
public static class EndpointExtensions
{
    // DTO to isolate input from complex relationships
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleEn { get; set; } = null!;
        public string RoleAr { get; set; } = null!;
        public bool? IsActive { get; set; }
    }

    public class UserRoleDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public int RoleId { get; set; }
        public bool? IsActive { get; set; }
    }
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

    public static WebApplication MapRoleEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/system");

        // POST Create Role
        group.MapPost("/tblroles", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            HttpContext httpContext,
            RoleDto roleDto) =>
        {
            try
            {
                // Map DTO to Entity
                var role = new TblRole
                {
                    RoleEn = roleDto.RoleEn,
                    RoleAr = roleDto.RoleAr,
                    IsActive = roleDto.IsActive ?? true
                };

                // Audit Fields
                string currentUser = httpContext.User.Identity?.Name ?? Environment.UserName;

                // Get Local IPv4 Address
                string currentIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ?.ToString() ?? "127.0.0.1";

                role.CreatedOn = DateTime.UtcNow;
                role.CreatedBy = currentUser;
                role.ModifiedOn = DateTime.UtcNow;
                role.ModifiedBy = currentUser;
                role.Ipaddress = currentIp;

                db.TblRoles.Add(role);
                await db.SaveChangesAsync();

                // Evict cache for TblRole
                await cacheStore.EvictByTagAsync("TblRole", default);

                // Return Result (map back if needed, or just return entity as it's clean now)
                return Results.Created($"/api/system/tblroles/{role.Id}", role);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("System");

        // PUT Update Role
        group.MapPut("/tblroles/{id}", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            HttpContext httpContext,
            int id,
            RoleDto roleDto) =>
        {
            try
            {
                // Lookup by ID
                var existingRole = await db.TblRoles.FindAsync(id);
                if (existingRole == null)
                {
                    return Results.NotFound();
                }

                // Update Scalar Properties ONLY
                existingRole.RoleEn = roleDto.RoleEn;
                existingRole.RoleAr = roleDto.RoleAr;
                existingRole.IsActive = roleDto.IsActive;

                // SET Audit Fields
                string currentUser = httpContext.User.Identity?.Name ?? Environment.UserName;
                string currentIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ?.ToString() ?? "127.0.0.1";

                existingRole.ModifiedBy = currentUser;
                existingRole.ModifiedOn = DateTime.UtcNow;
                existingRole.Ipaddress = currentIp;

                await db.SaveChangesAsync();

                // Evict cache
                await cacheStore.EvictByTagAsync("TblRole", default);

                return Results.Ok(existingRole);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("System");

        // DELETE Role
        group.MapDelete("/tblroles/{id}", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            int id) =>
        {
            try
            {
                var role = await db.TblRoles.FindAsync(id);
                if (role == null)
                {
                    return Results.NotFound();
                }

                db.TblRoles.Remove(role);
                await db.SaveChangesAsync();

                // Evict cache
                await cacheStore.EvictByTagAsync("TblRole", default);

                return Results.Ok(role);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("System");

        return app;
    }

    public static WebApplication MapUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/system");

        // GET Admin Users (Decrypted Passwords)
        // Explicitly disable caching for this sensitive/admin endpoint
        group.MapGet("/tblusersadmin", async (
            ClinicDbContext db,
            IEncryptionService encryptionService,
            HttpRequest request,
            string? search = null,
            string? sort = null,
            string? order = null,
            int? page = 1,
            int? pageSize = 50) =>
        {
            try
            {
                int pageNumber = page ?? 1;
                int size = pageSize ?? 50;
                if (pageNumber < 1) pageNumber = 1;
                if (size < 1) size = 50;
                if (size > 1000) size = 1000;

                var query = db.TblUsers.AsQueryable();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = QueryService.ApplySearch(query, search);
                }

                query = QueryService.ApplyFilters(query, request.Query);
                query = QueryService.ApplySort(query, sort, order);

                var totalCount = await query.CountAsync();

                var items = await query
                    .Skip((pageNumber - 1) * size)
                    .Take(size)
                    .ToListAsync();

                // Decrypt passwords
                foreach (var user in items)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(user.UserPassword))
                        {
                            user.UserPassword = encryptionService.Decrypt(user.UserPassword);
                        }
                    }
                    catch
                    {
                        // In case of decryption failure (e.g. invalid format),
                        // keep the original encrypted string or show an error placeholder.
                        // Showing a placeholder to indicate the issue.
                        user.UserPassword = "!! DECRYPTION ERROR !!";
                    }
                }

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
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .CacheOutput(x => x.NoCache()) // No caching for admin/decrypted view
        .WithTags("System")
        .WithName("Get_TblUsersAdmin")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get all users with decrypted passwords (Admin)";
            operation.Description = "Retrieve all users with decrypted passwords.";
            return operation;
        });

        // POST Create User
        group.MapPost("/tblusers", async (
            ClinicDbContext db,
            IEncryptionService encryptionService,
            IOutputCacheStore cacheStore, // Inject cache store for eviction
            HttpContext httpContext,
            TblUser user) =>
        {
            try
            {
                // Encrypt password
                if (!string.IsNullOrEmpty(user.UserPassword))
                {
                    user.UserPassword = encryptionService.Encrypt(user.UserPassword);
                }

                // Audit Fields
                string currentUser = httpContext.User.Identity?.Name ?? Environment.UserName;

                // Get Local IPv4 Address
                string currentIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ?.ToString() ?? "127.0.0.1";

                user.CreatedOn = DateTime.UtcNow;
                user.CreatedBy = currentUser;
                user.ModifiedOn = DateTime.UtcNow;
                user.ModifiedBy = currentUser;
                user.Ipaddress = currentIp;
                user.IsActive = true; // Default to active if not specified

                db.TblUsers.Add(user);
                await db.SaveChangesAsync();

                // Evict cache for TblUser to keep generic endpoint fresh
                await cacheStore.EvictByTagAsync("TblUser", default);

                return Results.Created($"/api/system/tblusers/{user.Id}", user);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("System");

        // PUT Update User
        group.MapPut("/tblusers/{id}", async (
            ClinicDbContext db,
            IEncryptionService encryptionService,
            IOutputCacheStore cacheStore, // Inject cache store
            HttpContext httpContext,
            int id,
            TblUser user) =>
        {
            try
            {
                // Enforce ID from URL (ignore body ID)
                user.Id = id;

                // PK is UserName, so we must lookup by Id column
                var existingUser = await db.TblUsers.FirstOrDefaultAsync(u => u.Id == id);
                if (existingUser == null)
                {
                    return Results.NotFound();
                }

                // Capture immutable data before SetValues
                var originalUserName = existingUser.UserName;
                var originalCreatedBy = existingUser.CreatedBy;
                var originalCreatedOn = existingUser.CreatedOn;
                var originalPassword = existingUser.UserPassword;

                // Encrypt password if provided
                if (!string.IsNullOrEmpty(user.UserPassword))
                {
                     user.UserPassword = encryptionService.Encrypt(user.UserPassword);
                }

                // Handle UserName (Primary Key) Change
                if (user.UserName != originalUserName)
                {
                    // 1. Check for duplicates
                    var userNameExists = await db.TblUsers.AnyAsync(u => u.UserName == user.UserName);
                    if (userNameExists)
                    {
                        return Results.Conflict($"UserName '{user.UserName}' is already taken.");
                    }

                    // 2. Perform Raw SQL Update to rename the PK
                    // We must use ExecuteSqlRaw because EF Core cannot track PK changes
                    await db.Database.ExecuteSqlRawAsync("UPDATE tblUser SET UserName = {0} WHERE Id = {1}", user.UserName, id);

                    // 3. Clear ChangeTracker to detach the "old" entity version
                    db.ChangeTracker.Clear();

                    // 4. Re-fetch the user to get the new state/PK
                    existingUser = await db.TblUsers.FirstOrDefaultAsync(u => u.Id == id);
                    if (existingUser == null) return Results.NotFound(); // Should not happen
                }
                else
                {
                    // Ensure the incoming model matches existing to satisfy EF
                    user.UserName = existingUser.UserName;
                }

                // Apply updates from request body
                db.Entry(existingUser).CurrentValues.SetValues(user);

                // RESTORE Immutable Fields (Id is already handled by lookup)
                existingUser.UserName = originalUserName;
                existingUser.CreatedBy = originalCreatedBy;
                existingUser.CreatedOn = originalCreatedOn;

                // Restore password if empty
                if (string.IsNullOrEmpty(user.UserPassword))
                {
                    existingUser.UserPassword = originalPassword;
                }

                // SET Audit Fields
                string currentUser = httpContext.User.Identity?.Name ?? Environment.UserName;

                // Get Local IPv4 Address
                string currentIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ?.ToString() ?? "127.0.0.1";

                existingUser.ModifiedBy = currentUser;
                existingUser.ModifiedOn = DateTime.UtcNow;
                existingUser.Ipaddress = currentIp;

                await db.SaveChangesAsync();

                // Evict cache for TblUser
                await cacheStore.EvictByTagAsync("TblUser", default);

                return Results.Ok(existingUser);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("System");

        // DELETE User
        group.MapDelete("/tblusers/{id}", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore, // Inject cache store
            int id) =>
        {
            try
            {
                // PK is UserName, so lookup by Id
                var user = await db.TblUsers.FirstOrDefaultAsync(u => u.Id == id);
                if (user == null)
                {
                    return Results.NotFound();
                }

                db.TblUsers.Remove(user);
                await db.SaveChangesAsync();

                // Evict cache for TblUser
                await cacheStore.EvictByTagAsync("TblUser", default);

                return Results.Ok(user); // Returning deleted object is helpful sometimes
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("System");

        return app;
    }

    public static WebApplication MapUserRoleEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/system");

        // POST Create UserRole
        group.MapPost("/tbluserroles", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            HttpContext httpContext,
            UserRoleDto userRoleDto) =>
        {
            try
            {
                // Map DTO to Entity
                var userRole = new TblUserRole
                {
                    LfUserName = userRoleDto.UserName,
                    LfRoleId = userRoleDto.RoleId,
                    IsActive = userRoleDto.IsActive ?? true
                };

                // Audit Fields
                string currentUser = httpContext.User.Identity?.Name ?? Environment.UserName;

                // Get Local IPv4 Address
                string currentIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ?.ToString() ?? "127.0.0.1";

                userRole.CreatedOn = DateTime.UtcNow;
                userRole.CreatedBy = currentUser;
                userRole.ModifiedOn = DateTime.UtcNow;
                userRole.ModifiedBy = currentUser;
                userRole.Ipaddress = currentIp;

                db.TblUserRoles.Add(userRole);
                await db.SaveChangesAsync();

                // Evict cache for TblUserRole
                await cacheStore.EvictByTagAsync("TblUserRole", default);

                return Results.Created($"/api/system/tbluserroles/{userRole.Id}", userRole);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("System");

        // PUT Update UserRole
        group.MapPut("/tbluserroles/{id}", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            HttpContext httpContext,
            int id,
            UserRoleDto userRoleDto) =>
        {
            try
            {
                // Lookup by ID
                var existingUserRole = await db.TblUserRoles.FindAsync(id);
                if (existingUserRole == null)
                {
                    return Results.NotFound();
                }

                // Update Scalar Properties
                existingUserRole.LfUserName = userRoleDto.UserName;
                existingUserRole.LfRoleId = userRoleDto.RoleId;
                existingUserRole.IsActive = userRoleDto.IsActive;

                // SET Audit Fields
                string currentUser = httpContext.User.Identity?.Name ?? Environment.UserName;
                string currentIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ?.ToString() ?? "127.0.0.1";

                existingUserRole.ModifiedBy = currentUser;
                existingUserRole.ModifiedOn = DateTime.UtcNow;
                existingUserRole.Ipaddress = currentIp;

                await db.SaveChangesAsync();

                // Evict cache
                await cacheStore.EvictByTagAsync("TblUserRole", default);

                return Results.Ok(existingUserRole);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("System");

        // DELETE UserRole
        group.MapDelete("/tbluserroles/{id}", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            int id) =>
        {
            try
            {
                var userRole = await db.TblUserRoles.FindAsync(id);
                if (userRole == null)
                {
                    return Results.NotFound();
                }

                db.TblUserRoles.Remove(userRole);
                await db.SaveChangesAsync();

                // Evict cache
                await cacheStore.EvictByTagAsync("TblUserRole", default);

                return Results.Ok(userRole);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("System");

        return app;
    }
}
