namespace Clinic2026_API.Exceptions;

/// <summary>
/// Exception for 404 Not Found scenarios
/// </summary>
public class NotFoundException : CustomException
{
    public NotFoundException(string resourceName, object key)
        : base(
            message: $"{resourceName} with key '{key}' was not found.",
            statusCode: 404,
            errorCode: "RESOURCE_NOT_FOUND",
            additionalData: new Dictionary<string, object>
            {
                { "resourceName", resourceName },
                { "key", key }
            })
    {
    }

    public NotFoundException(string message)
        : base(message, statusCode: 404, errorCode: "NOT_FOUND")
    {
    }
}
