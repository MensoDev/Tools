namespace Menso.Tools.Exceptions;

internal partial class When
{
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
}