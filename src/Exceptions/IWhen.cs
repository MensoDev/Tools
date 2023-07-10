using System.Runtime.CompilerServices;

namespace Menso.Tools.Exceptions;

public interface IWhen
{
    #region Generic types

    void BeNull<T>([NotNull] T? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void BeNotNull<T>(T? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);

    #endregion

    #region String type

    void BeEmpty(string argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void BeEmptyOrNull(string? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void BeNullOrWhiteSpace(string? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);

    #endregion

    #region Enumerable type

    void BeEmpty<T>(IEnumerable<T> argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void BeEmptyOrNull<T>(IEnumerable<T>? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);

    #endregion

    #region Guid type

    void BeEmpty(Guid argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void BeEmptyOrNull(Guid? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);

    #endregion

    #region Boolean type

    void BeTrue(bool argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void BeFalse(bool argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);

    #endregion

}