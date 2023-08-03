namespace Menso.Tools.Exceptions;

public interface IWhenGuid
{
    void Empty(Guid argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
    void NullOrEmpty([NotNull] Guid? argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null);
}