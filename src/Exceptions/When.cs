namespace Menso.Tools.Exceptions;

internal partial class When : IWhen
{
    private readonly Func<ExceptionInformation, Exception> _exceptionCreator;

    public When(Func<ExceptionInformation, Exception> exceptionCreator) => _exceptionCreator = exceptionCreator;

    [DoesNotReturn]
    private void ThrowException(string defaultMessage, string? customMessage, string? paramName, Exception? innerException = null)
    {
        throw _exceptionCreator(new ExceptionInformation(defaultMessage, customMessage, paramName, innerException));
    }
}