using System.Runtime.CompilerServices;

namespace Menso.Tools.Exceptions;

internal class When : IWhen
{
    private readonly Func<ExceptionInformation, Exception> _exceptionCreator;
    public When(Func<ExceptionInformation, Exception> exceptionCreator) => _exceptionCreator = exceptionCreator;
    
    [DoesNotReturn]
    private void ThrowException(string defaultMessage, string? customMessage, string? paramName, Exception? innerException = null) 
        => throw _exceptionCreator(new ExceptionInformation(defaultMessage, customMessage, paramName, innerException));

    #region Generic types

    public void IsNull<T>([NotNull] T? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is null)
        {
            ThrowException($"Argument '{paramName}' must not be null", message, paramName, innerException);
        }
    }

    public void IsNotNull<T>(T? argument, string? message = null, Exception? innerException = null, string? paramName = null)
    {
        if (argument is not null)
        {
            ThrowException($"Argument '{paramName}' must be null", message, paramName, innerException);
        }
    }

    #endregion

    #region String type

    public void IsEmpty(string argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (string.IsNullOrEmpty(argument))
        {
            ThrowException($"Argument '{paramName}' must not be empty", message, paramName, innerException);
        }
    }

    #endregion
    
    #region Enumerable type
    
    public void IsEmpty<T>(IEnumerable<T> argument, string? message = null, Exception? innerException = null, string? paramName = null)
    {
        if (argument.Any() is false)
        {
            ThrowException($"Argument '{paramName}' must not be empty", message, paramName, innerException);
        }
    }
    
    #endregion
    
}