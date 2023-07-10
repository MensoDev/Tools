namespace Menso.Tools.Exceptions;

public delegate Exception CreateExceptionHandle(ExceptionInformation exceptionInformation);

public delegate Exception CreateHttpExceptionHandle(HttpStatusCode statusCode, ExceptionInformation exceptionInformation);

public static class ExceptionSettings
{
    public static CreateExceptionHandle? CreateDefaultExceptionHandle { get; set; }
    public static CreateHttpExceptionHandle? CreateDefaultHttpExceptionHandle { get; set; }
}