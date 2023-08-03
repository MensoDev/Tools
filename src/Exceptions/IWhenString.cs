namespace Menso.Tools.Exceptions;

public interface IWhenString
{
    void Empty(string argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void NullOrEmpty([NotNull] string? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void NullOrWhiteSpace([NotNull] string? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
}