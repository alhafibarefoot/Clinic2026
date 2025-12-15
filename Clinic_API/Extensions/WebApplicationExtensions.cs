using Clinic2026_API.Middleware;
using Microsoft.EntityFrameworkCore;

namespace Clinic2026_API.Extensions;

/// <summary>
/// Extension methods for configuring the HTTP request pipeline
/// </summary>
public static class WebApplicationExtensions
{
    /// <summary>
    /// Configure middleware pipeline
    /// </summary>
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
        // Global exception handling (must be first)
        app.UseMiddleware<GlobalExceptionMiddleware>();

        // Swagger
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinic2026 API v1");
            c.RoutePrefix = string.Empty; // Swagger at root
        });

        // Security & CORS
        app.UseHttpsRedirection();
        app.UseCors();
        app.UseOutputCache();

        return app;
    }


}
