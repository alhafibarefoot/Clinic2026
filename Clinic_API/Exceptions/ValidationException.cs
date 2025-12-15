namespace Clinic2026_API.Exceptions;

/// <summary>
/// Exception for validation errors with field-level error details
/// </summary>
public class ValidationException : CustomException
{
    public Dictionary<string, string[]> Errors { get; }

    public ValidationException(Dictionary<string, string[]> errors)
        : base(
            message: "One or more validation errors occurred.",
            statusCode: 400,
            errorCode: "VALIDATION_ERROR")
    {
        Errors = errors;
    }

    public ValidationException(string field, string error)
        : base(
            message: "Validation error occurred.",
            statusCode: 400,
            errorCode: "VALIDATION_ERROR")
    {
        Errors = new Dictionary<string, string[]>
        {
            { field, new[] { error } }
        };
    }

    public ValidationException(string message)
        : base(message, statusCode: 400, errorCode: "VALIDATION_ERROR")
    {
        Errors = new Dictionary<string, string[]>();
    }
}
