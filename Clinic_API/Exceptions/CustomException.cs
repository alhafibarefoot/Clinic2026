namespace Clinic2026_API.Exceptions;

/// <summary>
/// Base custom exception class with HTTP status code support
/// </summary>
public class CustomException : Exception
{
    public int StatusCode { get; }
    public string? ErrorCode { get; }
    public Dictionary<string, object>? AdditionalData { get; }

    public CustomException(
        string message,
        int statusCode = 500,
        string? errorCode = null,
        Dictionary<string, object>? additionalData = null,
        Exception? innerException = null)
        : base(message, innerException)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
        AdditionalData = additionalData;
    }
}
