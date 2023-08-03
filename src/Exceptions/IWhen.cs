namespace Menso.Tools.Exceptions;

public interface IWhen : IWhenString, IWhenGuid, IWhenBoolean, IWhenEnumerable
{
    #region Generic types

    void Null<T>([NotNull] T? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void NotNull<T>(T? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void Equal<T>(T? expected, T? actual, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(actual))] string? paramName = null);
    void NotEqual<T>(T? notExpected, T? actual, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(actual))] string? paramName = null);

    #endregion
    
}