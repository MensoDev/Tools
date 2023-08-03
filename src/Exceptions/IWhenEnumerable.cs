namespace Menso.Tools.Exceptions;

public interface IWhenEnumerable
{
    void Empty<T>(IEnumerable<T> argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void NullOrEmpty<T>([NotNull] IEnumerable<T>? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
}