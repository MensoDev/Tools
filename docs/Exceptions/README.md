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
        // Create your own exception and return it
        
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
        // Create your own exception and return it
        
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
    
    Throw.When.Null(argument);
    Throw.When.Null(argument, message);
    Throw.When.Null(argument, message, innerException);
              
    Throw<CustomException>.When.Null(argument);
    Throw<CustomException>.When.Null(argument, message);
    Throw<CustomException>.When.Null(argument, message, innerException);    
}
```

```csharp
public void Sample_WithHttpException()
{
    object? argument = null;
    var message = "sample message";
    var innerException = new Exception("Inner exception");
    
    Throw.Http.BadRequest.When.Null(argument);
    Throw.Http.BadRequest.When.Null(argument, message);
    Throw.Http.BadRequest.When.Null(argument, message, innerException); 
}
```

### We are open to suggestions and collaborations