using System.Runtime.CompilerServices;

namespace Menso.Tools.Exceptions;

internal class When : IWhen
{
    private readonly Func<ExceptionInformation, Exception> _exceptionCreator;

    public When(Func<ExceptionInformation, Exception> exceptionCreator)
    {
        _exceptionCreator = exceptionCreator;
    }

    [DoesNotReturn]
    private void ThrowException(string defaultMessage, string? customMessage, string? paramName, Exception? innerException = null)
    {
        throw _exceptionCreator(new ExceptionInformation(defaultMessage, customMessage, paramName, innerException));
    }

    #region Generic types

    public void BeNull<T>([NotNull] T? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is null)
            ThrowException($"Argument '{paramName}' must not be null", message, paramName, innerException);
    }

    public void BeNotNull<T>(T? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is not null)
            ThrowException($"Argument '{paramName}' must be null", message, paramName, innerException);
    }

    #endregion

    #region String type

    public void BeEmpty(string argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (string.Empty == argument)
            ThrowException($"Argument '{paramName}' must not be empty", message, paramName, innerException);
    }

    public void BeEmptyOrNull(string? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (string.IsNullOrEmpty(argument))
            ThrowException($"Argument '{paramName}' must not be null or empty", message, paramName, innerException);
    }

    public void BeNullOrWhiteSpace(string? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (string.IsNullOrWhiteSpace(argument))
            ThrowException($"Argument '{paramName}' must not be null or white space", message, paramName, innerException);
    }

    #endregion

    #region Enumerable type

    public void BeEmpty<T>(IEnumerable<T> argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument.Any() is false)
            ThrowException($"Argument '{paramName}' must not be empty", message, paramName, innerException);
    }

    public void BeEmptyOrNull<T>(IEnumerable<T>? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is null || argument.Any() is false)
            ThrowException($"Argument '{paramName}' must not be null or empty", message, paramName, innerException);
    }

    #endregion

    #region Guid type

    public void BeEmpty(Guid argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument == Guid.Empty)
            ThrowException($"Argument '{paramName}' must not be empty", message, paramName, innerException);
    }

    public void BeEmptyOrNull(Guid? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is null || argument == Guid.Empty)
            ThrowException($"Argument '{paramName}' must not be null or empty", message, paramName, innerException);
    }

    #endregion

    #region  Bollean type
    
    public void BeTrue(bool argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument)
            ThrowException($"Argument '{paramName}' must be false", message, paramName, innerException);
    }
    
    public void BeFalse(bool argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is false)
            ThrowException($"Argument '{paramName}' must be true", message, paramName, innerException);
    }

    #endregion
}