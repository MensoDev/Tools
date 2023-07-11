namespace Menso.Tools.Exceptions;

public delegate Exception CreateExceptionHandler(ExceptionInformation exceptionInformation);
public delegate Exception CreateHttpExceptionHandler(HttpStatusCode statusCode, ExceptionInformation exceptionInformation);

public static class ExceptionSettings
{
    public static CreateExceptionHandler? CreateDefaultExceptionHandle { get; set; }
    public static CreateHttpExceptionHandler? CreateDefaultHttpExceptionHandle { get; set; }
}