using Clinic2026_API.Data;
using Clinic2026_API.Models.Entities;
using Clinic2026_API.Services;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace Clinic2026_API.Extensions;

public static class UserEndpointExtensions
{
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
}
