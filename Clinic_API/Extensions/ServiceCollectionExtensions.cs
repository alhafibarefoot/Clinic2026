using Clinic2026_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Barefoot API",
                Version = "v1",
                Description = "BareFoot Minimal API Build in dotnet new webapi -minimal. Hosted at github [here](https://github.com/YourRepo).\n\nComprehensive Medical Clinic Management API with full database coverage.",
                TermsOfService = new Uri("https://alhafi.barefoot.com/terms"),
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Alhafi.BareFoot",
                    Url = new Uri("https://alhafi.barefoot.com"),
                    Email = "Alhafi.BareFoot@example.com"
                },
                License = new Microsoft.OpenApi.Models.OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            });

            // Enable Authorization using JWT (Bearer)
            c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Description = "Enter your JWT token in the text input below (no 'Bearer' prefix needed).",
                Name = "Authorization",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });

            c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new List<string>()
                }
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


    /// <summary>
    /// Add JWT and Static Token Authentication
    /// </summary>
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"];

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "SmartAuth";
            options.DefaultChallengeScheme = "SmartAuth";
        })
        .AddJwtBearer("Bearer", options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                    System.Text.Encoding.UTF8.GetBytes(secretKey!))
            };
        })
        .AddScheme<Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions, StaticTokenAuthenticationHandler>(
            StaticTokenAuthenticationHandler.SchemeName, null)
        .AddPolicyScheme("SmartAuth", "Bearer or Static Token", options =>
        {
            options.ForwardDefaultSelector = context =>
            {
                var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                if (authHeader?.StartsWith("Bearer barefoot2020", StringComparison.OrdinalIgnoreCase) == true ||
                    authHeader?.Equals("barefoot2020", StringComparison.OrdinalIgnoreCase) == true)
                {
                    return StaticTokenAuthenticationHandler.SchemeName;
                }
                return "Bearer";
            };
        });

        services.AddAuthorization(options =>
        {
            // Default policy requires authenticated user (via either scheme)
            options.AddPolicy("Authenticated", policy => policy.RequireAuthenticatedUser());
        });

        return services;
    }
}
