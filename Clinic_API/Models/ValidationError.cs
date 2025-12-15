namespace Clinic2026_API.Models;

/// <summary>
/// Model for validation error details with field-specific errors
/// </summary>
public class ValidationError
{
    /// <summary>
    /// The field or property name that failed validation
    /// </summary>
    public string Field { get; set; } = string.Empty;

    /// <summary>
    /// The validation error message
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// The attempted value that failed validation
    /// </summary>
    public object? AttemptedValue { get; set; }

    /// <summary>
    /// The validation rule that was violated
    /// </summary>
    public string? ValidationRule { get; set; }
}
