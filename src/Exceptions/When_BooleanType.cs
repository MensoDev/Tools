﻿namespace Menso.Tools.Exceptions;

internal partial class When
{
    #region  Boolean type
    
    public void BeTrue(bool argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument)
            ThrowException($"Argument '{paramName}' must be false", message, paramName, innerException);
    }
    
    public void BeFalse(bool argument, string? message = null, Exception? innerException = null, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        if (argument is false)
            ThrowException($"Argument '{paramName}' must be true", message, paramName, innerException);
    }

    #endregion
}