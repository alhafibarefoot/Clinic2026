using Clinic2026_API.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic2026_API.Extensions;

/// <summary>
/// Extension methods for configuring services in the DI container
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add application services (DbContext, Caching, etc.)
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Database
        services.AddDbContext<ClinicDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null)));

        // Output Cache
        services.AddOutputCache(options =>
        {
            options.AddBasePolicy(builder =>
                builder.Expire(TimeSpan.FromMinutes(5))
                       .SetVaryByQuery("*")); // Vary by all query params

            // Longer cache for Lookup tables (365 days)
            options.AddPolicy("LookupPolicy", builder =>
                builder.Expire(TimeSpan.FromDays(365))
                       .SetVaryByQuery("*")); // Vary by all query params
        });

        // Memory Cache (Keep if needed elsewhere, otherwise usually safe to keep for other things)
        services.AddMemoryCache();

        // Encryption Service
        services.AddScoped<Services.IEncryptionService, Services.EncryptionService>();

        // ProblemDetails for standardized error responses
        services.AddProblemDetails();

        return services;
    }

    /// <summary>
    /// Add Swagger/OpenAPI documentation
    /// </summary>
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new()
            {
                Title = "Clinic2026 API",
                Version = "v1",
                Description = "Comprehensive Medical Clinic Management API with full database coverage"
            });
        });

        return services;
    }

    /// <summary>
    /// Add CORS policy
    /// </summary>
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        return services;
    }
}
