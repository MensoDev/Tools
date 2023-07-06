namespace Menso.Tools.Exceptions.Tests;

public class ThrowTests
{
    #region Generics types

    [Fact]
    public void IsNull_WhenArgumentIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => Throw.When.IsNull(argument);

        // Assert
        execution
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null (Parameter 'argument')");
    }
    
    [Fact]
    public void IsNull_WhenArgumentIsNotNull_DoesNotThrowException()
    {
        // Arrange
        var argument = new object();

        // Act
        var execution = () => Throw.When.IsNull(argument);

        // Assert
        execution.Should().NotThrow();
    }

    #endregion
    
    #region String type
    
    [Fact]
    public void IsEmpty_WhenStringArgumentIsEmpty_ThrowsArgumentException()
    {
        // Arrange
        var argument = string.Empty;

        // Act
        var execution = () => Throw.When.IsEmpty(argument);

        // Assert
        execution
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage("Argument 'argument' must not be empty (Parameter 'argument')");
    }
    
    [Fact]
    public void IsEmpty_WhenStringArgumentIsNotEmpty_DoesNotThrowException()
    {
        // Arrange
        const string argument = "not empty";

        // Act
        var execution = () => Throw.When.IsEmpty(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    #endregion
    
    #region Enumerable type
    
    [Fact]
    public void IsEmpty_WhenEnumerableArgumentIsEmpty_ThrowsArgumentException()
    {
        // Arrange
        var argument = Enumerable.Empty<object>();

        // Act
        var execution = () => Throw.When.IsEmpty(argument);

        // Assert
        execution
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage("Argument 'argument' must not be empty (Parameter 'argument')");
    }
    
    [Fact]
    public void IsEmpty_WhenEnumerableArgumentIsNotEmpty_DoesNotThrowException()
    {
        // Arrange
        var argument = new[] { new object() };

        // Act
        var execution = () => Throw.When.IsEmpty(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    #endregion

    #region HttpExceptionContext
    
    [Fact]
    public void HttpContext_IsNull_WhenArgumentIsNull_ThrowsCustomException_Forbidden()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => Throw.Http.Forbidden.When.IsNull(argument);

        // Assert
        execution
            .Should()
            .ThrowExactly<HttpRequestException>()
            .WithMessage("Forbidden: Argument 'argument' must not be null");
    }
    
    [Fact]
    public void HttpContext_IsNull_WhenArgumentIsNull_HttpRequestException_Unauthorized()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => Throw.Http.Unauthorized.When.IsNull(argument);

        // Assert
        execution
            .Should()
            .ThrowExactly<HttpRequestException>()
            .WithMessage("Unauthorized: Argument 'argument' must not be null");
    }
    
    [Fact]
    public void HttpContext_IsNull_WhenArgumentIsNull_ThrowsDefaultException_BadRequest()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => Throw.Http.BadRequest.When.IsNull(argument);

        // Assert
        execution
            .Should()
            .ThrowExactly<HttpRequestException>()
            .WithMessage("BadRequest: Argument 'argument' must not be null");
    }
    
    [Fact]
    public void HttpContext_IsNull_WhenArgumentIsNull_ThrowsDefaultException_NotFound()
    {
        // Arrange
        object? argument = null;
    
        // Act
        var execution = () => Throw.Http.NotFound.When.IsNull(argument);
        
        // Assert
        execution
            .Should()
            .ThrowExactly<HttpRequestException>()
            .WithMessage("NotFound: Argument 'argument' must not be null");
    }
    #endregion
}