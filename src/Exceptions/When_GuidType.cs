namespace Menso.Tools.Exceptions;

internal partial class When
{
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
}