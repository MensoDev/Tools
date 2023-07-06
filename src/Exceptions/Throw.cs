using Menso.Tools.Exceptions.Contexts;

namespace Menso.Tools.Exceptions;

public static partial class Throw
{
    public static IWhen When { get; } = new When(ExceptionCreator.CreateException);
}

public static partial class Throw
{
    public static class Http
    {
        public static IExceptionContext BadRequest { get; } = new HttpExceptionContext(HttpStatusCode.BadRequest);
        public static IExceptionContext Forbidden { get; } = new HttpExceptionContext(HttpStatusCode.Forbidden);
        public static IExceptionContext Unauthorized { get; } = new HttpExceptionContext(HttpStatusCode.Unauthorized);
        public static IExceptionContext NotFound { get; } = new HttpExceptionContext(HttpStatusCode.NotFound);
    }
}