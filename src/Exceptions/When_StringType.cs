

namespace Menso.Tools.Exceptions;

internal partial class When
{
    #region String type

    public void Empty(string argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (string.Empty == argument)
            ThrowException($"Argument '{paramName}' must not be empty", message, paramName, innerException);
    }

    public void EmptyOrNull([NotNull] string? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (string.IsNullOrEmpty(argument))
            ThrowException($"Argument '{paramName}' must not be null or empty", message, paramName, innerException);
    }

    public void NullOrWhiteSpace([NotNull] string? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (string.IsNullOrWhiteSpace(argument))
            ThrowException($"Argument '{paramName}' must not be null or white space", message, paramName, innerException);
    }

    #endregion
}