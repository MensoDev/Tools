# Tools.Exceptions
Helps avoid code complexity and improves readability

## Quick Installation Guide

### Install Package

```shell 

dotnet add package Menso.Tools.Exceptions

```

### Configuration (Optional)

```csharp
public void ConfigureExceptionLaucher(this IServiceCollection services)
{
    ExceptionSettings.CreateExceptionHandler = exceptionInformation =>
    {
        // Crete your own exception and return it
        
        // sample
        var message = exceptionInformation.CustomMessage ?? exceptionInformation.DefaultMessage;
        var paramName = exceptionInformation.ParamName;
        return new ArgumentException(message, paramName, exceptionInformation.InnerException);
    };
}
```

```csharp
public void ConfigureExceptionLaucher(this IServiceCollection services)
{
    ExceptionSettings.CreateHttpExceptionHandler = (statusCode, exceptionInformation) =>
    {
        // Crete your own exception and return it
        
        // sample
        var message = exceptionInformation.CustomMessage ?? $"{errorStatusCode}: {exceptionInformation.DefaultMessage}";
        return new HttpRequestException(message, exceptionInformation.InnerException, errorStatusCode);
    };
}
```

## Usage

### Use cases:

```csharp
public void Sample()
{
    object? argument = null;
    var message = "sample message";
    var innerException = new Exception("Inner exception");
    
    Throw.When.BeNull(argument);
    Throw.When.BeNull(argument, message);
    Throw.When.BeNull(argument, message, innerException);
              
    Throw<CustomException>.When.BeNull(argument);
    Throw<CustomException>.When.BeNull(argument, message);
    Throw<CustomException>.When.BeNull(argument, message, innerException);    
}
```

<br>

### We are open to suggestions and collaborations