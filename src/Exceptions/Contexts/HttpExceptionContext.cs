namespace Menso.Tools.Exceptions.Contexts;

internal class HttpExceptionContext : IExceptionContext
{
    private readonly HttpStatusCode _errorStatusCode;

    public HttpExceptionContext(HttpStatusCode errorStatusCode)
    {
        _errorStatusCode = errorStatusCode;
        When = new When(CreateException);
    }

    public IWhen When { get; }

    private Exception CreateException(ExceptionInformation exceptionInformation)
    {
        return ExceptionCreator.CreateHttpException(_errorStatusCode, exceptionInformation);
    }
}