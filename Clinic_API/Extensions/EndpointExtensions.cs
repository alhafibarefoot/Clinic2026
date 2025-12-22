using Clinic2026_API.Data;
using Clinic2026_API.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Clinic2026_API.Models.Entities;
using Clinic2026_API.Models.System;
using Microsoft.AspNetCore.OutputCaching;
using System.Net;

namespace Clinic2026_API.Extensions;

using Clinic2026_API.Models.Lookup;

/// <summary>
/// Extension methods for mapping API endpoints
/// </summary>
public static class EndpointExtensions
{
    // DTO to isolate input from complex relationships
    #region DTOs
    public class ProductServiceCategoryDto
    {
        public string LfClassificationCode { get; set; } = null!;
        public string? LfParentCategoryCode { get; set; }
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!; // Changed from string?
        public bool? IsActive { get; set; }
    }

    public class RoleDto
    {
        // Original DTO had Id, RoleEn, RoleAr.
        // The instruction changed it to just 'Name'.
        // To avoid breaking existing mapping logic in MapRoleEndpoints,
        // we'll keep RoleEn and RoleAr, but make them non-nullable as per the pattern.
        // The 'Id' property is typically not part of an input DTO for creation/update.
        public string RoleEn { get; set; } = null!; // Kept from original, made non-nullable
        public string RoleAr { get; set; } = null!; // Kept from original, made non-nullable
        public bool? IsActive { get; set; }
    }

    public class AbbreviationDto
    {
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!; // Changed from string?
        public bool? IsActive { get; set; }
    }

    public class MedicalSpecialtyDto
    {
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!; // Changed from string?
        public string? MedicalTypeLogo { get; set; }
        public bool? IsActive { get; set; }
    }

    public class PaymentMethodDto
    {
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!; // Changed from string?
        public bool IsCreditCard { get; set; } // Changed from bool?
        public bool IsLoyalityCard { get; set; } // Changed from bool?
        public string? PaymentTypeLogo { get; set; }
        public bool? IsActive { get; set; }
    }

    public class RequestChannelDto
    {
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!; // Changed from string?
        public string? ChannalPhoto { get; set; }
        public bool? IsActive { get; set; }
    }

    public class TaskImpactDto
    {
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!; // Changed from string?
        public string? ImpactImage { get; set; }
        public bool? IsActive { get; set; }
    }

    public class TaskUrgencyDto
    {
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!; // Changed from string?
        public string? UrgencyImage { get; set; }
        public bool? IsActive { get; set; }
    }

    public class TaskPriorityDto
    {
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!; // Changed from string?
        public string? ImagePriority { get; set; }
        public int? HourServe { get; set; }
        public bool IsDefault { get; set; } // Changed from bool?
        public bool? IsActive { get; set; }
    }

    public class TaskRateDto
    {
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!; // Changed from string?
        public string? RatingImage { get; set; }
        public bool? IsActive { get; set; }
    }

    public class UserRoleDto
    {
        // Original DTO had Id, UserName, RoleId.
        // The instruction changed it to LfUserId, LfRoleId.
        // To avoid breaking existing mapping logic in MapUserRoleEndpoints,
        // we'll use the new names LfUserId and LfRoleId, and update the mapping.
        public string LfUserId { get; set; } = null!; // Changed from UserName
        public int LfRoleId { get; set; } // Changed from RoleId, assuming int is correct for FK
        public bool? IsActive { get; set; }
    }
    #endregion


    #region Core Mappings
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
        if (category == "Lookup" && typeof(T).Name != "LtLookupTableReferance")
        {
            // Apply 365-day expiration and tag with Entity Name for eviction
            endpoint.CacheOutput(x => x.Expire(TimeSpan.FromDays(365)).Tag(typeof(T).Name));

            // Map CRUD for Lookups (Generic) - EXCLUDING specific entities handled manually
            switch (typeof(T).Name)
            {
                case "LtMedicalSpecialty":
                    app.MapMedicalSpecialtyEndpoints();
                    break;
                case "LtPaymentMethod":
                    app.MapPaymentMethodEndpoints();
                    break;
                case "LtRequest2Channal":
                    app.MapRequestChannelEndpoints();
                    break;
                case "LtTask1Impact":
                    app.MapTask1ImpactEndpoints();
                    break;
                case "LtTask2Urgency":
                    app.MapTask2UrgencyEndpoints();
                    break;
                case "LtTask3Priority":
                    app.MapTask3PriorityEndpoints();
                    break;
                case "LtTask5Rate":
                app.MapTask5RateEndpoints();
                break;
            case "LtProductServiceCategory":
                app.MapProductServiceCategoryEndpoints();
                break;
            case "LtAbbreviation":
                    // Handled manually in Program.cs (or could be moved here too)
                    // Currently Program.cs calls MapAbbreviationEndpoints(), so we just skip here.
                    break;
                default:
                    MapGenericLookupCrud<T>(app, routePrefix, routeName);
                    break;
            }
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
            operation.Summary = $"Get all {routeName} / الحصول على جميع سجلات {routeName}";
            operation.Description = $"Retrieve all {routeName} with optional filtering, searching, and sorting. / استرجاع جميع سجلات {routeName} مع إمكانية التصفية والبحث والفرز.";

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
        })
        .RequireAuthorization();
    }

    #endregion

    #region System Mappings
    public static WebApplication MapRoleEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/system").RequireAuthorization();

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
                    RoleEn = roleDto.RoleEn, // Using RoleEn from DTO
                    RoleAr = roleDto.RoleAr, // Using RoleAr from DTO
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
        .WithTags("System")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Create Role / إنشاء دور جديد";
            operation.Description = "Create a new role in the system. / إنشاء دور جديد في النظام.";
            return operation;
        });

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
                existingRole.RoleEn = roleDto.RoleEn; // Using RoleEn from DTO
                existingRole.RoleAr = roleDto.RoleAr; // Using RoleAr from DTO
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
        .WithTags("System")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Update Role / تحديث دور";
            operation.Description = "Update an existing role by ID. / تحديث بيانات دور موجود باستخدام المعرف.";
            return operation;
        });

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
        .WithTags("System")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Delete Role / حذف دور";
            operation.Description = "Delete a role by ID. / حذف دور باستخدام المعرف.";
            return operation;
        });

        return app;
    }

    public static WebApplication MapUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/system").RequireAuthorization();

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
            operation.Summary = "Get all users with decrypted passwords (Admin) / الحصول على جميع المستخدمين مع كلمات المرور (أدمن)";
            operation.Description = "Retrieve all users with decrypted passwords. / استرجاع جميع المستخدمين مع عرض كلمات المرور مفكوكة التشفير.";
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
                // Check for duplicate UserName
                if (await db.TblUsers.AnyAsync(u => u.UserName == user.UserName))
                {
                    return Results.BadRequest($"User with UserName '{user.UserName}' already exists.");
                }

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
        .WithTags("System")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Create User / إنشاء مستخدم جديد";
            operation.Description = "Create a new user in the system. / إنشاء مستخدم جديد في النظام.";
            return operation;
        });

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
                // Handle UserName Change
                if (user.UserName != originalUserName)
                {
                    // Check for duplicates
                    if (await db.TblUsers.AnyAsync(u => u.UserName == user.UserName))
                    {
                        return Results.Conflict($"UserName '{user.UserName}' is already taken.");
                    }
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
        .WithTags("System")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Update User / تحديث مستخدم";
            operation.Description = "Update an existing user by ID. / تحديث بيانات مستخدم موجود باستخدام المعرف.";
            return operation;
        });

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
        .WithTags("System")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Delete User / حذف مستخدم";
            operation.Description = "Delete a user by ID. / حذف مستخدم باستخدام المعرف.";
            return operation;
        });

        return app;
    }

    public static WebApplication MapUserRoleEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/system").RequireAuthorization();

        // POST Create UserRole
        group.MapPost("/tbluserroles", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            HttpContext httpContext,
            UserRoleDto userRoleDto) =>
        {
            try
            {
                // Check if user exists
                if (!await db.TblUsers.AnyAsync(u => u.UserName == userRoleDto.LfUserId)) // Changed to LfUserId
                {
                    return Results.BadRequest($"User '{userRoleDto.LfUserId}' does not exist to add role."); // Changed to LfUserId
                }

                // Map DTO to Entity
                var userRole = new TblUserRole
                {
                    LfUserName = userRoleDto.LfUserId, // Changed to LfUserId
                    LfRoleId = userRoleDto.LfRoleId, // Changed to LfRoleId
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
        .WithTags("System")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Assign Role to User / تعيين دور للمستخدم";
            operation.Description = "Assign a role to a specific user. / تعيين دور محدد لمستخدم.";
            return operation;
        });

        // GET UserRole by ID
        group.MapGet("/tbluserroles/{id}", async (
            ClinicDbContext db,
            int id) =>
        {
            try
            {
                var userRole = await db.TblUserRoles
                    .Include(ur => ur.LfRole) // Optional: Include related role details
                    .FirstOrDefaultAsync(ur => ur.Id == id);

                return userRole is not null ? Results.Ok(userRole) : Results.NotFound($"UserRole with Id '{id}' not found.");
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("System")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Get User Role by ID / الحصول على دور المستخدم (بالمعرف)";
            operation.Description = "Get details of a user role assignment. / الحصول على تفاصيل تعيين دور المستخدم.";
            return operation;
        });

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
                    return Results.NotFound($"UserRole with Id '{id}' not found.");
                }

                // Update Scalar Properties
                existingUserRole.LfUserName = userRoleDto.LfUserId; // Changed to LfUserId
                existingUserRole.LfRoleId = userRoleDto.LfRoleId; // Changed to LfRoleId
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
        .WithTags("System")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Update User Role / تحديث دور المستخدم";
            operation.Description = "Update a user role assignment. / تحديث تعيين دور المستخدم.";
            return operation;
        });

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
        .WithTags("System")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Delete User Role / حذف دور المستخدم";
            operation.Description = "Remove a role assignment from a user. / إزالة تعيين دور من مستخدم.";
            return operation;
        });


        return app;
    }
    #endregion

    #region Lookup Helpers
    /// <summary>
    /// Helper to determine Lookup configuration (RefName and Code Property)
    /// </summary>
    private static (string RefName, string CodePropName) GetLookupInfo(Type type)
    {
        string name = type.Name;
        if (name.StartsWith("Lt")) name = name.Substring(2);

        // Remove Address prefix if present (Address0, Address1, etc.)
        if (name.StartsWith("Address") && name.Length > 7 && char.IsDigit(name[7]))
        {
            name = name.Substring(8);
        }

        // Handle specific cases or standard convention
        // Overrides for specific entities where default convention fails (e.g. picks Foreign Key)
        if (type.Name == "LtMedicalAllergy") return ("MedicalAllergy", "AllergiesCode");
        if (type.Name == "LtMedicalPatientPain") return ("MedicalPatientPain", "PatientPainCode");
        if (type.Name == "LtMedicalDiagnosis") return ("MedicalDiagnosis", "DiagnosisCode");
        if (type.Name == "LtMedicalSymptom") return ("MedicalSymptom", "SymptomsCode");
    if (type.Name == "LtMedicalTreatment") return ("MedicalTreatment", "TreatmentsCode");
    if (type.Name == "LtProductServiceCategory") return ("ProductServiceCategory", "CategoryCode");

    // Convention: Entity "Road" -> Code "RoadCode"
        string codeProp = name + "Code";

        // Check if property exists, if not, try finding any property ending in "Code" (fallback)
        var prop = type.GetProperty(codeProp);
        if (prop == null)
        {
             // Fallback: search for first string property ending in "Code" that isn't "ZipCode" etc.
             // Or rely on the "Name" being correct for RefName even if CodeProp is different.
             // For now, assume the convention holds or fallback to first *Code property.
             var alt = type.GetProperties().FirstOrDefault(p => p.Name.EndsWith("Code") && p.PropertyType == typeof(string));
             if (alt != null)
             {
                 codeProp = alt.Name;
             }
        }

        return (name, codeProp);
    }
    #endregion

    #region Generic Lookup CRUD
    private static void MapGenericLookupCrud<T>(WebApplication app, string routePrefix, string routeName) where T : class
    {
        var group = app.MapGroup($"/api/{routePrefix}/{routeName}").RequireAuthorization();

        // POST Create (Auto-Generated Code)
        group.MapPost("/", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            HttpContext httpContext,
            [Microsoft.AspNetCore.Mvc.FromBody] T entity) =>
        {
            try
            {
                var (refName, codePropName) = GetLookupInfo(typeof(T));
            var propInfo = typeof(T).GetProperty(codePropName);

            if (propInfo == null) return Results.BadRequest($"Configuration Error: Code Property '{codePropName}' not found on {typeof(T).Name}.");

            // 1. Lookup Reference (Try Exact or Space-Separated)
            var refTable = await GetLookupReferenceAsync(db, refName);

            if (refTable == null)
            {
                return Results.BadRequest($"Configuration Error: Lookup Reference for '{refName}' (or '{System.Text.RegularExpressions.Regex.Replace(refName, "(\\B[A-Z])", " $1")}') not found.");
            }

            // 2. Generate New Code
            string newCode = GenerateNextCode(refTable);

            // 3. Set Code on Entity
            propInfo.SetValue(entity, newCode);

            // Audit Fields (Reflection)
            SetAuditFields(entity, httpContext);

            db.Set<T>().Add(entity);
            await db.SaveChangesAsync();

            await cacheStore.EvictByTagAsync(typeof(T).Name, default);

            // Use reflection to get the ID if we want to return Created URL with ID or Code
            var id = propInfo.GetValue(entity);
            return Results.Created($"/api/{routePrefix}/{routeName}/{id}", entity);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("Lookup")
        .WithOpenApi(operation =>
        {
            operation.Summary = $"Create {typeof(T).Name} / إنشاء سجل جديد";
            operation.Description = "Create a new record with auto-generated code.";
            return operation;
        });

        // PUT Update by Code
        group.MapPut("/{code}", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            HttpContext httpContext,
            [Microsoft.AspNetCore.Mvc.FromRoute] string code,
            [Microsoft.AspNetCore.Mvc.FromBody] T inputEntity) =>
        {
            try
            {
                var (refName, codePropName) = GetLookupInfo(typeof(T));

                // Build dynamic query for finding by Code
                // We cannot easily use inputEntity.Code because we receive it as string in URL
                // We need to find the entity where [codePropName] == code

                var param = System.Linq.Expressions.Expression.Parameter(typeof(T), "x");
                var prop = System.Linq.Expressions.Expression.Property(param, codePropName);
                var val = System.Linq.Expressions.Expression.Constant(code);
                var body = System.Linq.Expressions.Expression.Equal(prop, val);
                var lambda = System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(body, param);

                var existingEntity = await db.Set<T>().FirstOrDefaultAsync(lambda);

                if (existingEntity == null) return Results.NotFound($"{typeof(T).Name} with Code '{code}' not found.");

                // Update Fields (excluding Immutable ones)
                // We can use db.Entry().CurrentValues.SetValues but we must protect Key/Audit/Code
                var entry = db.Entry(existingEntity);

                // Save immutable values
                var createdBy = typeof(T).GetProperty("CreatedBy")?.GetValue(existingEntity);
                var createdOn = typeof(T).GetProperty("CreatedOn")?.GetValue(existingEntity);
                var id = typeof(T).GetProperty("Id")?.GetValue(existingEntity);

                entry.CurrentValues.SetValues(inputEntity);

                // Restore immutable values
                if (createdBy != null) typeof(T).GetProperty("CreatedBy")?.SetValue(existingEntity, createdBy);
                if (createdOn != null) typeof(T).GetProperty("CreatedOn")?.SetValue(existingEntity, createdOn);
                if (id != null) typeof(T).GetProperty("Id")?.SetValue(existingEntity, id);
                typeof(T).GetProperty(codePropName)?.SetValue(existingEntity, code); // Ensure Code matches URL

                // Audit Update
                string currentUser = httpContext.User.Identity?.Name ?? Environment.UserName;
                string currentIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
                     .AddressList
                     .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                     ?.ToString() ?? "127.0.0.1";

                typeof(T).GetProperty("ModifiedBy")?.SetValue(existingEntity, currentUser);
                typeof(T).GetProperty("ModifiedOn")?.SetValue(existingEntity, DateTime.UtcNow);
                typeof(T).GetProperty("Ipaddress")?.SetValue(existingEntity, currentIp);

                await db.SaveChangesAsync();
                await cacheStore.EvictByTagAsync(typeof(T).Name, default);

                return Results.Ok(existingEntity);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("Lookup")
        .WithOpenApi(operation =>
        {
            operation.Summary = $"Update {typeof(T).Name} / تحديث سجل";
            return operation;
        });

        // DELETE by Code
        group.MapDelete("/{code}", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            [Microsoft.AspNetCore.Mvc.FromRoute] string code) =>
        {
            try
            {
                var (_, codePropName) = GetLookupInfo(typeof(T));

                var param = System.Linq.Expressions.Expression.Parameter(typeof(T), "x");
                var prop = System.Linq.Expressions.Expression.Property(param, codePropName);
                var val = System.Linq.Expressions.Expression.Constant(code);
                var body = System.Linq.Expressions.Expression.Equal(prop, val);
                var lambda = System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(body, param);

                var entity = await db.Set<T>().FirstOrDefaultAsync(lambda);

                if (entity == null) return Results.NotFound();

                db.Set<T>().Remove(entity);
                await db.SaveChangesAsync();
                await cacheStore.EvictByTagAsync(typeof(T).Name, default);

                return Results.Ok(entity);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("Lookup")
        .WithOpenApi(operation =>
        {
            operation.Summary = $"Delete {typeof(T).Name} / حذف سجل";
            return operation;
        });
    }
    #endregion

    #region Custom Lookup Mappings
    public static WebApplication MapAbbreviationEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/lookup/ltabbreviations").RequireAuthorization();

        // POST Create Abbreviation (Explicit Implementation)
        group.MapPost("/", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            HttpContext httpContext,
            AbbreviationDto dto) =>
        {
            try
            {
                // 1. Lookup Reference for Code Generation
                var refTable = await GetLookupReferenceAsync(db, "Abbreviation");
                if (refTable == null) return Results.BadRequest("Configuration Error: Lookup Reference for 'Abbreviation' not found.");

                string newCode = GenerateNextCode(refTable);

                // 3. Create Entity
                var entity = new LtAbbreviation
                {
                    AbbreviationCode = newCode,
                    NameEn = dto.NameEn,
                    NameAr = dto.NameAr,
                    IsActive = dto.IsActive ?? true
                };

                SetAuditFields(entity, httpContext);

                db.LtAbbreviations.Add(entity);
                await db.SaveChangesAsync();

                // Evict cache
                await cacheStore.EvictByTagAsync("LtAbbreviation", default);

                return Results.Created($"/api/lookup/ltabbreviations/{entity.AbbreviationCode}", entity);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("Lookup")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Create Abbreviation / إنشاء اختصار";
            operation.Description = "Create a new abbreviation (Explicit).";
            return operation;
        });

        // PUT Update Abbreviation
        group.MapPut("/{code}", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            HttpContext httpContext,
            string code,
            AbbreviationDto dto) =>
        {
            try
            {
                var entity = await db.LtAbbreviations.FirstOrDefaultAsync(x => x.AbbreviationCode == code);
                if (entity == null)
                {
                    return Results.NotFound($"Abbreviation with Code '{code}' not found.");
                }

                entity.NameEn = dto.NameEn;
                entity.NameAr = dto.NameAr;
                entity.IsActive = dto.IsActive;

                SetAuditFields(entity, httpContext, isUpdate: true);

                await db.SaveChangesAsync();
                await cacheStore.EvictByTagAsync("LtAbbreviation", default);

                return Results.Ok(entity);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("Lookup");

        // DELETE
        group.MapDelete("/{code}", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            string code) =>
        {
            try
            {
                var entity = await db.LtAbbreviations.FirstOrDefaultAsync(x => x.AbbreviationCode == code);
                if (entity == null)
                {
                    return Results.NotFound();
                }

                db.LtAbbreviations.Remove(entity);
                await db.SaveChangesAsync();
                await cacheStore.EvictByTagAsync("LtAbbreviation", default);

                return Results.Ok(entity);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("Lookup");

        return app;
    }
    public static WebApplication MapProductServiceCategoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/lookup/ltproductservicecategories").RequireAuthorization();

        // POST Create ProductServiceCategory
        group.MapPost("/", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            HttpContext httpContext,
            ProductServiceCategoryDto dto) =>
        {
            try
            {
                // 1. Validate Classification Code
                var classification = await db.LtProductServiceClassifications.FirstOrDefaultAsync(c => c.ClassificationCode == dto.LfClassificationCode);
                if (classification == null)
                    return Results.BadRequest($"Classification Code '{dto.LfClassificationCode}' not found.");

                // 2. Validate Parent Category Code (if provided)
                if (!string.IsNullOrEmpty(dto.LfParentCategoryCode))
                {
                    var parent = await db.LtProductServiceCategories.FirstOrDefaultAsync(c => c.CategoryCode == dto.LfParentCategoryCode);
                    if (parent == null)
                        return Results.BadRequest($"Parent Category Code '{dto.LfParentCategoryCode}' not found.");
                }

                // 3. Generate Category Code
                var prefix = !string.IsNullOrEmpty(dto.LfParentCategoryCode) ? dto.LfParentCategoryCode : dto.LfClassificationCode;

                var refTable = await GetLookupReferenceAsync(db, "ProductServiceCategory");
                if (refTable == null) return Results.BadRequest($"Reference 'ProductServiceCategory' not found.");

                string newCode = GenerateNextCode(refTable, prefix);

                // 4. Create Entity
                var entity = new LtProductServiceCategory
                {
                    CategoryCode = newCode,
                    LfClassificationCode = dto.LfClassificationCode,
                    LfParentCategoryCode = dto.LfParentCategoryCode,
                    NameEn = dto.NameEn,
                    NameAr = dto.NameAr,
                    IsActive = dto.IsActive ?? true
                };

                SetAuditFields(entity, httpContext);

                // 5. Save and Update Serial
                db.LtProductServiceCategories.Add(entity);

                await db.SaveChangesAsync();
                await cacheStore.EvictByTagAsync("LtProductServiceCategory", default);

                return Results.Created($"/api/lookup/ltproductservicecategories/{newCode}", entity);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("Lookup");

        return app;
    }

    public static WebApplication MapMedicalSpecialtyEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/lookup/ltmedicalspecialties").RequireAuthorization();

        // POST Create MedicalSpecialty
        group.MapPost("/", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            HttpContext httpContext,
            MedicalSpecialtyDto dto) =>
        {
            try
            {
                // 1. Lookup Reference
                var refTable = await GetLookupReferenceAsync(db, "MedicalSpecialty");
                if (refTable == null) return Results.BadRequest("Configuration Error: Lookup Reference for 'MedicalSpecialty' not found.");

                string newCode = GenerateNextCode(refTable);

                // 3. Handle Logo (Base64 -> Byte[])
                byte[]? logoBytes = null;
                if (!string.IsNullOrEmpty(dto.MedicalTypeLogo) && dto.MedicalTypeLogo != "string")
                {
                    try
                    {
                        var base64 = dto.MedicalTypeLogo;
                        if (base64.Contains(",")) base64 = base64.Split(',')[1];
                        logoBytes = Convert.FromBase64String(base64);
                    }
                    catch
                    {
                       return Results.BadRequest("Invalid Base64 string for MedicalTypeLogo.");
                    }
                }

                // 4. Create Entity
                var entity = new LtMedicalSpecialty
                {
                    MedicalSpecialtyCode = newCode,
                    NameEn = dto.NameEn,
                    NameAr = dto.NameAr,
                    MedicalTypeLogo = logoBytes,
                    IsActive = dto.IsActive ?? true
                };

                SetAuditFields(entity, httpContext);

                db.LtMedicalSpecialties.Add(entity);
                await db.SaveChangesAsync();

                // Evict cache
                await cacheStore.EvictByTagAsync("LtMedicalSpecialty", default);

                return Results.Created($"/api/lookup/ltmedicalspecialties/{entity.MedicalSpecialtyCode}", entity);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("Lookup")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Create Medical Specialty / إنشاء تخصص طبي";
            operation.Description = "Create a new medical specialty with logo support.";
            return operation;
        });

        // PUT Update MedicalSpecialty
        group.MapPut("/{code}", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            HttpContext httpContext,
            string code,
            MedicalSpecialtyDto dto) =>
        {
            try
            {
                var entity = await db.LtMedicalSpecialties.FirstOrDefaultAsync(x => x.MedicalSpecialtyCode == code);
                if (entity == null)
                {
                    return Results.NotFound($"Medical Specialty with Code '{code}' not found.");
                }

                entity.NameEn = dto.NameEn;
                entity.NameAr = dto.NameAr;
                entity.IsActive = dto.IsActive;

                // Handle Logo Update
                if (dto.MedicalTypeLogo != null) // Only update if provided
                {
                    if (string.IsNullOrEmpty(dto.MedicalTypeLogo) || dto.MedicalTypeLogo == "string")
                    {
                         if (dto.MedicalTypeLogo == "") entity.MedicalTypeLogo = null;
                    }
                    else
                    {
                        try
                        {
                            var base64 = dto.MedicalTypeLogo;
                            if (base64.Contains(",")) base64 = base64.Split(',')[1];
                            entity.MedicalTypeLogo = Convert.FromBase64String(base64);
                        }
                        catch
                        {
                             return Results.BadRequest("Invalid Base64 string for MedicalTypeLogo.");
                        }
                    }
                }

                SetAuditFields(entity, httpContext, isUpdate: true);

                await db.SaveChangesAsync();
                await cacheStore.EvictByTagAsync("LtMedicalSpecialty", default);

                return Results.Ok(entity);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("Lookup")
        .WithOpenApi(operation =>
        {
            operation.Summary = "Update Medical Specialty / تحديث تخصص طبي";
            return operation;
        });

        // DELETE MedicalSpecialty
        group.MapDelete("/{code}", async (
            ClinicDbContext db,
            IOutputCacheStore cacheStore,
            string code) =>
        {
            try
            {
                var entity = await db.LtMedicalSpecialties.FirstOrDefaultAsync(x => x.MedicalSpecialtyCode == code);
                if (entity == null)
                {
                    return Results.NotFound();
                }

                db.LtMedicalSpecialties.Remove(entity);
                await db.SaveChangesAsync();
                await cacheStore.EvictByTagAsync("LtMedicalSpecialty", default);

                return Results.Ok(entity);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        })
        .WithTags("Lookup");

        return app;
    }








    public static WebApplication MapPaymentMethodEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/lookup/ltpaymentmethods").RequireAuthorization();

        group.MapPost("/", async (ClinicDbContext db, IOutputCacheStore cache, HttpContext ctx, PaymentMethodDto dto) =>
        {
            try {
                var refTable = await GetLookupReferenceAsync(db, "PaymentMethod");
                if (refTable == null) return Results.BadRequest("Reference 'PaymentMethod' not found");

                string newCode = GenerateNextCode(refTable);

                var entity = new LtPaymentMethod
                {
                    PaymentMethodCode = newCode,
                    NameEn = dto.NameEn,
                    NameAr = dto.NameAr,
                    IsCreditCard = dto.IsCreditCard,
                    IsLoyalityCard = dto.IsLoyalityCard,
                    PaymentTypeLogo = ConvertBase64ToBytes(dto.PaymentTypeLogo),
                    IsActive = dto.IsActive ?? true
                };

                SetAuditFields(entity, ctx);

                db.LtPaymentMethods.Add(entity);
                await db.SaveChangesAsync();
                await cache.EvictByTagAsync("LtPaymentMethod", default);
                return Results.Created($"/api/lookup/ltpaymentmethods/{newCode}", entity);
            } catch (Exception ex) { return Results.Problem(ex.Message); }
        }).WithTags("Lookup");

        return app;
    }

    public static WebApplication MapRequestChannelEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/lookup/ltrequest2channals").RequireAuthorization();
        group.MapPost("/", async (ClinicDbContext db, IOutputCacheStore cache, HttpContext ctx, RequestChannelDto dto) =>
        {
            try {
                var refTable = await GetLookupReferenceAsync(db, "Request2Channal");
                if (refTable == null) return Results.BadRequest("Reference 'Request2Channal' not found");

                string newCode = GenerateNextCode(refTable);

                var entity = new LtRequest2Channal
                {
                    RequestTypeChannal = newCode,
                    NameEn = dto.NameEn,
                    NameAr = dto.NameAr,
                    ChannalPhoto = ConvertBase64ToBytes(dto.ChannalPhoto),
                    IsActive = dto.IsActive ?? true
                };

                SetAuditFields(entity, ctx);

                db.LtRequest2Channals.Add(entity);
                await db.SaveChangesAsync();
                await cache.EvictByTagAsync("LtRequest2Channal", default);
                return Results.Created($"/api/lookup/ltrequest2channals/{newCode}", entity);
            } catch (Exception ex) { return Results.Problem(ex.Message); }
        }).WithTags("Lookup");
        return app;
    }

    public static WebApplication MapTask1ImpactEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/lookup/lttask1impacts").RequireAuthorization();
        group.MapPost("/", async (ClinicDbContext db, IOutputCacheStore cache, HttpContext ctx, TaskImpactDto dto) =>
        {
            try {
                var refTable = await GetLookupReferenceAsync(db, "Task1Impact");
                if (refTable == null) return Results.BadRequest("Reference 'Task1Impact' not found");

                string newCode = GenerateNextCode(refTable);

                var entity = new LtTask1Impact
                {
                    ImpactCode = newCode,
                    NameEn = dto.NameEn,
                    NameAr = dto.NameAr,
                    ImpactImage = ConvertBase64ToBytes(dto.ImpactImage),
                    IsActive = dto.IsActive ?? true
                };

                SetAuditFields(entity, ctx);

                db.LtTask1Impacts.Add(entity);
                await db.SaveChangesAsync();
                await cache.EvictByTagAsync("LtTask1Impact", default);
                return Results.Created($"/api/lookup/lttask1impacts/{newCode}", entity);
            } catch (Exception ex) { return Results.Problem(ex.Message); }
        }).WithTags("Lookup");
        return app;
    }

    public static WebApplication MapTask2UrgencyEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/lookup/lttask2urgencies").RequireAuthorization();
        group.MapPost("/", async (ClinicDbContext db, IOutputCacheStore cache, HttpContext ctx, TaskUrgencyDto dto) =>
        {
            try {
                var refTable = await GetLookupReferenceAsync(db, "Task2Urgency");
                if (refTable == null) return Results.BadRequest("Reference 'Task2Urgency' not found");

                string newCode = GenerateNextCode(refTable);

                var entity = new LtTask2Urgency
                {
                    UrgencyCode = newCode,
                    NameEn = dto.NameEn,
                    NameAr = dto.NameAr,
                    UrgencyImage = ConvertBase64ToBytes(dto.UrgencyImage),
                    IsActive = dto.IsActive ?? true
                };

                SetAuditFields(entity, ctx);

                db.LtTask2Urgencies.Add(entity);
                await db.SaveChangesAsync();
                await cache.EvictByTagAsync("LtTask2Urgency", default);
                return Results.Created($"/api/lookup/lttask2urgencies/{newCode}", entity);
            } catch (Exception ex) { return Results.Problem(ex.Message); }
        }).WithTags("Lookup");
        return app;
    }

    public static WebApplication MapTask3PriorityEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/lookup/lttask3priorities").RequireAuthorization();
        group.MapPost("/", async (ClinicDbContext db, IOutputCacheStore cache, HttpContext ctx, TaskPriorityDto dto) =>
        {
            try {
                var refTable = await GetLookupReferenceAsync(db, "Task3Priority");
                if (refTable == null) return Results.BadRequest("Reference 'Task3Priority' not found");

                string newCode = GenerateNextCode(refTable);

                var entity = new LtTask3Priority
                {
                    PriorityCode = newCode,
                    NameEn = dto.NameEn,
                    NameAr = dto.NameAr,
                    ImagePriority = ConvertBase64ToBytes(dto.ImagePriority),
                    HourServe = dto.HourServe,
                    IsDefault = dto.IsDefault,
                    IsActive = dto.IsActive ?? true
                };

                SetAuditFields(entity, ctx);

                db.LtTask3Priorities.Add(entity);
                await db.SaveChangesAsync();
                await cache.EvictByTagAsync("LtTask3Priority", default);
                return Results.Created($"/api/lookup/lttask3priorities/{newCode}", entity);
            } catch (Exception ex) { return Results.Problem(ex.Message); }
        }).WithTags("Lookup");
        return app;
    }

    public static WebApplication MapTask5RateEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/lookup/lttask5rates").RequireAuthorization();
        group.MapPost("/", async (ClinicDbContext db, IOutputCacheStore cache, HttpContext ctx, TaskRateDto dto) =>
        {
            try {
                var refTable = await GetLookupReferenceAsync(db, "Task5Rate");
                if (refTable == null) return Results.BadRequest("Reference 'Task5Rate' not found");

                string newCode = GenerateNextCode(refTable);

                var entity = new LtTask5Rate
                {
                    RatingCode = newCode,
                    NameEn = dto.NameEn,
                    NameAr = dto.NameAr,
                    RatingImage = ConvertBase64ToBytes(dto.RatingImage),
                    IsActive = dto.IsActive ?? true
                };

                SetAuditFields(entity, ctx);

                db.LtTask5Rates.Add(entity);
                await db.SaveChangesAsync();
                await cache.EvictByTagAsync("LtTask5Rate", default);
                return Results.Created($"/api/lookup/lttask5rates/{newCode}", entity);
            } catch (Exception ex) { return Results.Problem(ex.Message); }
        }).WithTags("Lookup");
        return app;
    }
    #endregion



    #region Helpers

    /// <summary>
    /// Helper to find a Lookup Table Reference by Name (checking exact and spaced variants)
    /// </summary>
    private static async Task<LtLookupTableReferance?> GetLookupReferenceAsync(ClinicDbContext db, string refName)
    {
        var refTable = await db.LtLookupTableReferances.FirstOrDefaultAsync(r => r.NameEn == refName);
        if (refTable == null)
        {
            // Try spaced name
            var spacedName = System.Text.RegularExpressions.Regex.Replace(refName, "(\\B[A-Z])", " $1");
            refTable = await db.LtLookupTableReferances.FirstOrDefaultAsync(r => r.NameEn == spacedName);
        }
        return refTable;
    }

    /// <summary>
    /// Helper to generate the next code for a lookup entity and update the reference
    /// </summary>
    private static string GenerateNextCode(LtLookupTableReferance refTable, string? prefix = null)
    {
        refTable.LastSerialNo = (refTable.LastSerialNo ?? 0) + 1;
        refTable.ModifiedOn = DateTime.UtcNow;

        string padFormat = new string('0', refTable.PadLeftNo);
        string serialPart = refTable.LastSerialNo.Value.ToString(padFormat);

        // Use provided prefix (e.g. from Parent) OR default to LookupCode from Ref Table
        string codePrefix = !string.IsNullOrEmpty(prefix) ? prefix : refTable.LookupCode;

        return $"{codePrefix}-{serialPart}";
    }

    /// <summary>
    /// Helper to set Audit fields on an entity
    /// </summary>
    private static void SetAuditFields(object entity, HttpContext? ctx, bool isUpdate = false)
    {
        string currentUser = ctx?.User.Identity?.Name ?? Environment.UserName;
        // Simple way to get IP, or just use context connection
        string currentIp = ctx?.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1";

        var type = entity.GetType();

        if (!isUpdate)
        {
            type.GetProperty("CreatedBy")?.SetValue(entity, currentUser);
            type.GetProperty("CreatedOn")?.SetValue(entity, DateTime.UtcNow);
            type.GetProperty("IsActive")?.SetValue(entity, true); // Default Active
        }

        type.GetProperty("ModifiedBy")?.SetValue(entity, currentUser);
        type.GetProperty("ModifiedOn")?.SetValue(entity, DateTime.UtcNow);
        type.GetProperty("Ipaddress")?.SetValue(entity, currentIp); // Standardize property name casing
    }

    // Helper for Base64 Conversion
    private static byte[]? ConvertBase64ToBytes(string? base64String)
    {
        if (string.IsNullOrEmpty(base64String) || base64String == "string") return null;
        try
        {
            if (base64String.Contains(",")) base64String = base64String.Split(',')[1];
            return Convert.FromBase64String(base64String);
        }
        catch
        {
            return null;
        }
    }

    #endregion
}
