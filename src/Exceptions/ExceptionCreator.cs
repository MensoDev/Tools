namespace Menso.Tools.Exceptions;

internal static class ExceptionCreator
{
    public static Exception CreateException(ExceptionInformation exceptionInformation)
    {
        return ExceptionSettings.CreateDefaultExceptionHandle?.Invoke(exceptionInformation) ?? CreateDefaultException(exceptionInformation);
    }
    
    public static Exception CreateHttpException(HttpStatusCode errorStatusCode, ExceptionInformation exceptionInformation)
    {

        return ExceptionSettings.CreateDefaultHttpExceptionHandle?.Invoke(errorStatusCode, exceptionInformation) ?? CreateDefaultHttpException(errorStatusCode, exceptionInformation);
    }

    private static Exception CreateDefaultException(ExceptionInformation exceptionInformation)
    {
        var message = exceptionInformation.CustomMessage ?? exceptionInformation.DefaultMessage;
        var paramName = exceptionInformation.ParamName;
        return new ArgumentException(message, paramName, exceptionInformation.InnerException);
    }
    
    private static Exception CreateDefaultHttpException(HttpStatusCode errorStatusCode, ExceptionInformation exceptionInformation)
    {
        var message = exceptionInformation.CustomMessage ?? $"{errorStatusCode}: {exceptionInformation.DefaultMessage}";
        return new HttpRequestException(message, exceptionInformation.InnerException, errorStatusCode);
    }
}