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

        // Serve static files (CSS, Images for Swagger)
        app.UseStaticFiles();

        // Swagger
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinic2026 API v1");
            // c.RoutePrefix = string.Empty; // Restore default /swagger
            c.InjectStylesheet("/css/swagger-custom.css"); // Inject custom branding
            c.DocumentTitle = "BareFoot Swagger Documentation"; // Set window title
        });

        // Security & CORS
        app.UseHttpsRedirection();
        app.UseCors();
        app.UseOutputCache();

        return app;
    }


}
