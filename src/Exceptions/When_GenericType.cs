namespace Menso.Tools.Exceptions;

internal partial class When
{
    #region Generic types

    public void BeNull<T>([NotNull] T? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is null)
            ThrowException($"Argument '{paramName}' must not be null", message, paramName, innerException);
    }

    public void NotBeNull<T>(T? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is not null)
            ThrowException($"Argument '{paramName}' must be null", message, paramName, innerException);
    }

    public void AreEqual<T>(T? expected, T? actual, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(actual))] string? paramName = null)
    {
        if(AreEqualsInternal(expected, actual))
            ThrowException($"Argument '{paramName}' must be not equal to '{expected}'", message, paramName, innerException);
    }

    public void AreNotEqual<T>(T? notExpected, T? actual, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(actual))] string? paramName = null)
    {
        if(AreEqualsInternal(notExpected, actual) is false)
            ThrowException($"Argument '{paramName}' must be equal to '{notExpected}'", message, paramName, innerException);
    }

    #endregion
    
    private static bool AreEqualsInternal<T>(T? expected, T? actual)
    {
        return expected is null && actual is null || expected is not null && expected.Equals(actual) || actual is not null && actual.Equals(expected);
    }
}