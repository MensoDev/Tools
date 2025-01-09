namespace Menso.Tools.Exceptions;

internal partial class When(Func<ExceptionInformation, Exception> exceptionCreator) : IWhen
{
    [DoesNotReturn]
    private void ThrowException(string defaultMessage, string? customMessage, string? paramName, Exception? innerException = null)
    {
        throw exceptionCreator(new ExceptionInformation(defaultMessage, customMessage, paramName, innerException));
    }
}