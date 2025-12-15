namespace Clinic2026_API.Models;

/// <summary>
/// Standardized error response model following RFC 7807 Problem Details
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// A URI reference that identifies the problem type
    /// </summary>
    public string Type { get; set; } = "about:blank";

    /// <summary>
    /// A short, human-readable summary of the problem type
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The HTTP status code
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// A human-readable explanation specific to this occurrence of the problem
    /// </summary>
    public string Detail { get; set; } = string.Empty;

    /// <summary>
    /// A URI reference that identifies the specific occurrence of the problem
    /// </summary>
    public string? Instance { get; set; }

    /// <summary>
    /// Error code for programmatic error handling
    /// </summary>
    public string? ErrorCode { get; set; }

    /// <summary>
    /// Timestamp when the error occurred
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Additional error details (e.g., validation errors)
    /// </summary>
    public Dictionary<string, object>? Extensions { get; set; }
}
