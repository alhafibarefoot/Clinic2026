using Clinic2026_API.Exceptions;
using Clinic2026_API.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace Clinic2026_API.Middleware;

/// <summary>
/// Global exception handling middleware that catches all unhandled exceptions
/// </summary>
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger,
        IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        // Log the exception
        LogException(exception);

        // Create error response
        var errorResponse = CreateErrorResponse(context, exception);

        // Set response properties
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = errorResponse.Status;

        // Serialize and write response
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = _environment.IsDevelopment()
        };

        var json = JsonSerializer.Serialize(errorResponse, options);
        await context.Response.WriteAsync(json);
    }

    private ErrorResponse CreateErrorResponse(HttpContext context, Exception exception)
    {
        var errorResponse = new ErrorResponse
        {
            Instance = context.Request.Path,
            Timestamp = DateTime.UtcNow
        };

        switch (exception)
        {
            case CustomException customEx:
                errorResponse.Status = customEx.StatusCode;
                errorResponse.Title = GetTitleForStatusCode(customEx.StatusCode);
                errorResponse.Detail = customEx.Message;
                errorResponse.ErrorCode = customEx.ErrorCode;

                if (customEx.AdditionalData != null)
                {
                    errorResponse.Extensions = customEx.AdditionalData;
                }

                // Add validation errors if it's a ValidationException
                if (customEx is ValidationException validationEx && validationEx.Errors.Any())
                {
                    errorResponse.Extensions ??= new Dictionary<string, object>();
                    errorResponse.Extensions["errors"] = validationEx.Errors;
                }
                break;

            case DbUpdateException dbEx:
                errorResponse.Status = (int)HttpStatusCode.InternalServerError;
                errorResponse.Title = "Database Error";
                errorResponse.Detail = _environment.IsDevelopment()
                    ? dbEx.Message
                    : "A database error occurred while processing your request.";
                errorResponse.ErrorCode = "DATABASE_ERROR";
                break;

            case UnauthorizedAccessException:
                errorResponse.Status = (int)HttpStatusCode.Unauthorized;
                errorResponse.Title = "Unauthorized";
                errorResponse.Detail = "You are not authorized to access this resource.";
                errorResponse.ErrorCode = "UNAUTHORIZED";
                break;

            case ArgumentNullException argNullEx:
                errorResponse.Status = (int)HttpStatusCode.BadRequest;
                errorResponse.Title = "Bad Request";
                errorResponse.Detail = _environment.IsDevelopment()
                    ? $"Required parameter '{argNullEx.ParamName}' is missing."
                    : "A required parameter is missing.";
                errorResponse.ErrorCode = "MISSING_PARAMETER";
                break;

            case ArgumentException argEx:
                errorResponse.Status = (int)HttpStatusCode.BadRequest;
                errorResponse.Title = "Bad Request";
                errorResponse.Detail = argEx.Message;
                errorResponse.ErrorCode = "INVALID_ARGUMENT";
                break;

            case InvalidOperationException:
                errorResponse.Status = (int)HttpStatusCode.BadRequest;
                errorResponse.Title = "Invalid Operation";
                errorResponse.Detail = _environment.IsDevelopment()
                    ? exception.Message
                    : "The requested operation is invalid.";
                errorResponse.ErrorCode = "INVALID_OPERATION";
                break;

            case TimeoutException:
                errorResponse.Status = (int)HttpStatusCode.RequestTimeout;
                errorResponse.Title = "Request Timeout";
                errorResponse.Detail = "The request took too long to process.";
                errorResponse.ErrorCode = "TIMEOUT";
                break;

            default:
                errorResponse.Status = (int)HttpStatusCode.InternalServerError;
                errorResponse.Title = "Internal Server Error";
                errorResponse.Detail = _environment.IsDevelopment()
                    ? exception.Message
                    : "An unexpected error occurred while processing your request.";
                errorResponse.ErrorCode = "INTERNAL_ERROR";

                // Include stack trace in development
                if (_environment.IsDevelopment())
                {
                    errorResponse.Extensions = new Dictionary<string, object>
                    {
                        { "stackTrace", exception.StackTrace ?? string.Empty },
                        { "exceptionType", exception.GetType().Name }
                    };
                }
                break;
        }

        return errorResponse;
    }

    private void LogException(Exception exception)
    {
        var logLevel = exception switch
        {
            CustomException customEx when customEx.StatusCode < 500 => LogLevel.Warning,
            CustomException => LogLevel.Error,
            _ => LogLevel.Error
        };

        _logger.Log(logLevel, exception, "An exception occurred: {Message}", exception.Message);
    }

    private static string GetTitleForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Bad Request",
            401 => "Unauthorized",
            403 => "Forbidden",
            404 => "Not Found",
            409 => "Conflict",
            422 => "Unprocessable Entity",
            500 => "Internal Server Error",
            503 => "Service Unavailable",
            _ => "Error"
        };
    }
}
