using Clinic2026_API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddSwaggerDocumentation();
builder.Services.AddCorsPolicy();

var app = builder.Build();

// Configure middleware pipeline
app.ConfigureMiddleware();

// Map API endpoints
app.MapAllEntityEndpoints();
app.MapUserEndpoints();
app.MapRoleEndpoints();
app.MapUserRoleEndpoints();





app.Run();

// Partial class for Program to allow reflection
public partial class Program { }
