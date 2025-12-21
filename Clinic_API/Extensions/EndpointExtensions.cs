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
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleEn { get; set; } = null!;
        public string RoleAr { get; set; } = null!;
        public bool? IsActive { get; set; }
    }


    public class AbbreviationDto
    {
        public string NameEn { get; set; } = null!;
        public string? NameAr { get; set; }
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
        if (category == "Lookup" && typeof(T).Name != "LtLookupTableReferance")
        {
            // Apply 365-day expiration and tag with Entity Name for eviction
            endpoint.CacheOutput(x => x.Expire(TimeSpan.FromDays(365)).Tag(typeof(T).Name));

            // Map CRUD for Lookups (Generic) - EXCLUDING LtAbbreviation which is handled explicitly
            if (typeof(T).Name != "LtAbbreviation")
            {
                MapGenericLookupCrud<T>(app, routePrefix, routeName);
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
                if (!await db.TblUsers.AnyAsync(u => u.UserName == userRoleDto.UserName))
                {
                    return Results.BadRequest($"User '{userRoleDto.UserName}' does not exist to add role.");
                }

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
        // Convention: Entity "Road" -> Code "RoadCode"
        string codeProp = name + "Code";

        // Check if property exists, if not, try finding any property ending in "Code" (fallback)
        var prop = type.GetProperty(codeProp);
        if (prop == null)
        {
             // Fallback: search for first string property ending in "Code" that isn't "ZipCode" etc.
             // Or rely on the "Name" being correct for RefName even if CodeProp is different.
             // For now, assume the convention holds or fallback to first *Code property.
             prop = type.GetProperties().FirstOrDefault(p => p.Name.EndsWith("Code") && p.PropertyType == typeof(string));
             if (prop != null) codeProp = prop.Name;
        }

        return (name, codeProp);
    }

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
                // e.g. "AccountingDocumentType" OR "Accounting Document Type"
                var refTable = await db.LtLookupTableReferances.FirstOrDefaultAsync(r => r.NameEn == refName);

                if (refTable == null)
                {
                    // Try adding spaces to PascalCase
                    var spacedName = System.Text.RegularExpressions.Regex.Replace(refName, "(\\B[A-Z])", " $1");
                    refTable = await db.LtLookupTableReferances.FirstOrDefaultAsync(r => r.NameEn == spacedName);
                }

                if (refTable == null)
                {
                    return Results.BadRequest($"Configuration Error: Lookup Reference for '{refName}' (or '{System.Text.RegularExpressions.Regex.Replace(refName, "(\\B[A-Z])", " $1")}') not found.");
                }

                // 2. Generate New Code
                refTable.LastSerialNo = (refTable.LastSerialNo ?? 0) + 1;
                refTable.ModifiedOn = DateTime.UtcNow;

                string padFormat = new string('0', refTable.PadLeftNo);
                string newCode = $"{refTable.LookupCode}-{refTable.LastSerialNo.Value.ToString(padFormat)}";

                // 3. Set Code on Entity
                propInfo.SetValue(entity, newCode);

                // Audit Fields (Reflection)
                string currentUser = httpContext.User.Identity?.Name ?? Environment.UserName;
                string currentIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ?.ToString() ?? "127.0.0.1";

                var setAudit = (string prop, object val) =>
                {
                    var p = typeof(T).GetProperty(prop);
                    if (p != null && p.CanWrite) p.SetValue(entity, val);
                };

                setAudit("CreatedBy", currentUser);
                setAudit("CreatedOn", DateTime.UtcNow);
                setAudit("ModifiedBy", currentUser);
                setAudit("ModifiedOn", DateTime.UtcNow);
                setAudit("Ipaddress", currentIp);
                setAudit("IsActive", true); // Default to active if present

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
                var refName = "Abbreviation";
                var refTable = await db.LtLookupTableReferances.FirstOrDefaultAsync(r => r.NameEn == refName);

                if (refTable == null)
                {
                    return Results.BadRequest("Configuration Error: Lookup Reference for 'Abbreviation' not found.");
                }

                // 2. Generate New Code
                refTable.LastSerialNo = (refTable.LastSerialNo ?? 0) + 1;
                refTable.ModifiedOn = DateTime.UtcNow;

                string padFormat = new string('0', refTable.PadLeftNo);
                string newCode = $"{refTable.LookupCode}-{refTable.LastSerialNo.Value.ToString(padFormat)}";

                // 3. Create Entity
                var entity = new LtAbbreviation
                {
                    AbbreviationCode = newCode,
                    NameEn = dto.NameEn,
                    NameAr = dto.NameAr,
                    IsActive = dto.IsActive ?? true
                };

                // Audit Fields
                string currentUser = httpContext.User.Identity?.Name ?? Environment.UserName;
                string currentIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
                    .AddressList
                    .FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    ?.ToString() ?? "127.0.0.1";

                entity.CreatedOn = DateTime.UtcNow;
                entity.CreatedBy = currentUser;
                entity.ModifiedOn = DateTime.UtcNow;
                entity.ModifiedBy = currentUser;
                entity.Ipaddress = currentIp;

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

                // Audit
                string currentUser = httpContext.User.Identity?.Name ?? Environment.UserName;
                entity.ModifiedBy = currentUser;
                entity.ModifiedOn = DateTime.UtcNow;

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
}
