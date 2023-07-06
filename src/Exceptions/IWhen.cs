using System.Runtime.CompilerServices;

namespace Menso.Tools.Exceptions;

public interface IWhen
{
    
    #region Generic types

    void IsNull<T>([NotNull] T? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void IsNotNull<T>(T? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);

    #endregion

    #region String type
    
    void IsEmpty(string argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    
    #endregion

    #region Enumerable type
    
    void IsEmpty<T>(IEnumerable<T> argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);

    #endregion

}