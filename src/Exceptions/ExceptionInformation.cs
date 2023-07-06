namespace Menso.Tools.Exceptions;

public record ExceptionInformation(string DefaultMessage, string? CustomMessage, string? ParamName, Exception? InnerException = null);