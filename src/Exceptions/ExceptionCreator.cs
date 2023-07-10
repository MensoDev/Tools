namespace Menso.Tools.Exceptions;

internal static class ExceptionCreator
{
    public static Exception CreateException(ExceptionInformation exceptionInformation)
    {
        return ExceptionSettings.CreateDefaultExceptionHandle?.Invoke(exceptionInformation) ?? CreateDefaultException(exceptionInformation);
    }

    public static Exception CreateException<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TException>(ExceptionInformation exceptionInformation) where TException : Exception
    {
        return CreateGenericException<TException>(exceptionInformation);
    }

    public static Exception CreateHttpException(HttpStatusCode errorStatusCode, ExceptionInformation exceptionInformation)
    {
        return ExceptionSettings.CreateDefaultHttpExceptionHandle?.Invoke(errorStatusCode, exceptionInformation) ?? CreateDefaultHttpException(errorStatusCode, exceptionInformation);
    }

    private static Exception CreateDefaultException(ExceptionInformation exceptionInformation)
    {
        var message = exceptionInformation.CustomMessage ?? exceptionInformation.DefaultMessage;
        var paramName = exceptionInformation.ParamName;
        return new ArgumentException(message, paramName, exceptionInformation.InnerException);
    }

    private static Exception CreateGenericException<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TException>(ExceptionInformation information) where TException : Exception
    {
        var message = information.CustomMessage ?? information.DefaultMessage;
        var type = typeof(TException);

        if (information.InnerException is not null)
        {
            var constructor = type.GetConstructor(new[] { typeof(string), typeof(Exception) }) ??
                              throw new ArgumentException($"The exception of type {type.Name} does not have a suitable constructor. ctor (message, innerException)");

            return (TException)constructor.Invoke(new object[] { message, information.InnerException });
        }
        else
        {
            var constructor = type.GetConstructor(new[] { typeof(string) }) ??
                              throw new ArgumentException($"The exception of type {type.Name} does not have a suitable constructor. ctor (message)");
            
            return (TException)constructor.Invoke(new object[] { message });
        }
    }

    private static Exception CreateDefaultHttpException(HttpStatusCode errorStatusCode, ExceptionInformation exceptionInformation)
    {
        var message = exceptionInformation.CustomMessage ?? $"{errorStatusCode}: {exceptionInformation.DefaultMessage}";
        return new HttpRequestException(message, exceptionInformation.InnerException, errorStatusCode);
    }
}