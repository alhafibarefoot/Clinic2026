namespace Clinic2026_API.Exceptions;

/// <summary>
/// Exception for database operation failures
/// </summary>
public class DatabaseException : CustomException
{
    public DatabaseException(string message, Exception? innerException = null)
        : base(
            message: message,
            statusCode: 500,
            errorCode: "DATABASE_ERROR",
            additionalData: null,
            innerException: innerException)
    {
    }

    public DatabaseException(string operation, string entity, Exception? innerException = null)
        : base(
            message: $"Database error occurred while {operation} {entity}.",
            statusCode: 500,
            errorCode: "DATABASE_ERROR",
            additionalData: new Dictionary<string, object>
            {
                { "operation", operation },
                { "entity", entity }
            },
            innerException: innerException)
    {
    }
}
