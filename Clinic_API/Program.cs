using Clinic2026_API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddApplicationServices(builder.Configuration);

// Configure JSON serialization (Ignore Cycles)
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddSwaggerDocumentation();
builder.Services.AddCorsPolicy();

builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();

// Configure middleware pipeline
app.ConfigureMiddleware();

// Enable Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// Map API endpoints
app.MapAuthEndpoints();
app.MapAllEntityEndpoints();
app.MapUserEndpoints();
app.MapRoleEndpoints();
app.MapUserRoleEndpoints();
app.MapTestEndpoints();
app.MapAbbreviationEndpoints();






app.Run();

// Partial class for Program to allow reflection
public partial class Program { }
