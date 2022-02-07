namespace Astor.Template.WebApi;

public record Error(HttpStatusCode Code, string Reason)
{
    public object Details { get; set; }

    public static Error Unknown => new(HttpStatusCode.InternalServerError, "Unknown");

    public static Error Interpret(Exception exception, bool showDetails)
    {
        var error = interpret(exception);
        if (showDetails)
        {
            error.Details = new
            {
                exceptionMessage = exception.Message,
                exceptionData = any(exception.Data) ? exception.Data : null,
                innerExceptionMessage = exception.InnerException?.Message,
                stackTrace = exception.StackTrace
            };
        }

        return error;
    }

    private static Error interpret(Exception exception)
    {
        return Unknown;
    }

    private static bool any(IEnumerable enumerable)
    {
        var enumerator = enumerable.GetEnumerator();
        return enumerator.MoveNext();
    }
}
