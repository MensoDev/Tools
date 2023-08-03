namespace Menso.Tools.Exceptions;

public interface IWhen
{
    #region Generic types

    void Null<T>([NotNull] T? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void NotNull<T>(T? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void Equal<T>(T? expected, T? actual, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(actual))] string? paramName = null);
    void NotEqual<T>(T? notExpected, T? actual, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(actual))] string? paramName = null);

    #endregion

    #region String type

    void Empty(string argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void EmptyOrNull([NotNull] string? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void NullOrWhiteSpace([NotNull] string? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);

    #endregion

    #region Enumerable type

    void Empty<T>(IEnumerable<T> argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void EmptyOrNull<T>([NotNull] IEnumerable<T>? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);

    #endregion

    #region Guid type

    void Empty(Guid argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void EmptyOrNull([NotNull] Guid? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);

    #endregion

    #region Boolean type

    void True(bool argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void False(bool argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void FalseOrNull([NotNull] bool? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);

    #endregion

}