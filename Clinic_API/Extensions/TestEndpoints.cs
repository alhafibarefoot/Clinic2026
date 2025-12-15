using Clinic2026_API.Data;
using Clinic2026_API.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Clinic2026_API.Extensions;

public static class TestEndpoints
{
    public static WebApplication MapTestEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/test")
           .WithTags("Testing")
           .AllowAnonymous(); // Allow access to trigger errors without auth blocking first

        // 404 Not Found
        group.MapGet("/not-found/{id}", (int id) =>
        {
            throw new KeyNotFoundException($"Entity with ID {id} was not found.");
        });

        // 400 Validation Error (Single)
        group.MapGet("/validation-single", () =>
        {
            throw new ArgumentException("Invalid argument provided for this operation.");
        });

        // 400 Validation Error (Multiple/Custom)
        group.MapGet("/validation-multiple", () =>
        {
            var errors = new Dictionary<string, string[]>
            {
                { "UserName", new[] { "UserName is required", "UserName must be unique" } },
                { "Email", new[] { "Invalid email format" } }
            };
            throw new Exceptions.ValidationException(errors);
        });

        // 500 Database Error (Simulated)
        group.MapGet("/database-error", () =>
        {
            throw new DbUpdateException("Simulated database update error.");
        });

        // Custom Error
        group.MapGet("/custom-error", () =>
        {
            throw new CustomException("This is a custom business logic error.", 418, "TEAPOT_ERROR");
        });

        // 401 Unauthorized (Thrown explicitly to test middleware)
        group.MapGet("/unauthorized", () =>
        {
            throw new UnauthorizedAccessException("You are not authorized to perform this test.");
        });

        // 400 Argument Null
        group.MapGet("/argument-null", () =>
        {
            string? value = null;
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Value cannot be null.");
            }
        });

        // 400 Invalid Operation
        group.MapGet("/invalid-operation", () =>
        {
            throw new InvalidOperationException("This operation is not allowed in the current state.");
        });

        // 408 Timeout
        group.MapGet("/timeout", () =>
        {
            throw new TimeoutException("The operation timed out.");
        });

        // 500 Generic Error
        group.MapGet("/generic-error", () =>
        {
            throw new Exception("Something went wrong unexpectedly.");
        });

        // 500 DB Update Error
        group.MapGet("/db-update-error", () =>
        {
            throw new DbUpdateException("Constraint violation occurred.");
        });

        // 200 Success
        group.MapGet("/success", () =>
        {
            return Results.Ok(new { Message = "Operation completed successfully.", Date = DateTime.UtcNow });
        });

        return app;
    }
}
