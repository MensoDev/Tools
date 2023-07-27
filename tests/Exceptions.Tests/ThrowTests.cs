namespace Menso.Tools.Exceptions.Tests;

public class ThrowTests
{
    #region Generics types

    [Fact]
    public void Null_WhenArgumentNull_ThrowsArgumentNullException()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => Throw.When.Null(argument);

        // Assert
        execution
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null (Parameter 'argument')");
    }

    [Fact]
    public void Null_WhenArgumentNotNull_DoesNotThrowException()
    {
        // Arrange
        var argument = new object();

        // Act
        var execution = () => Throw.When.Null(argument);

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
        var execution = () => Throw.When.Empty(argument);

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
        var execution = () => Throw.When.Empty(argument);

        // Assert
        execution.Should().NotThrow();
    }

    #endregion

    #region Enumerable type

    [Fact]
    public void Empty_WhenEnumerableArgumentEmpty_ThrowsArgumentException()
    {
        // Arrange
        var argument = Enumerable.Empty<object>();

        // Act
        var execution = () => Throw.When.Empty(argument);

        // Assert
        execution
            .Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage("Argument 'argument' must not be empty (Parameter 'argument')");
    }

    [Fact]
    public void Empty_WhenEnumerableArgumentNotEmpty_DoesNotThrowException()
    {
        // Arrange
        var argument = new[] { new object() };

        // Act
        var execution = () => Throw.When.Empty(argument);

        // Assert
        execution.Should().NotThrow();
    }

    #endregion

    #region HttpExceptionContext

    [Fact]
    public void HttpContext_Null_WhenArgumentNull_ThrowsCustomException_Forbidden()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => Throw.Http.Forbidden.When.Null(argument);

        // Assert
        execution
            .Should()
            .ThrowExactly<HttpRequestException>()
            .WithMessage("Forbidden: Argument 'argument' must not be null");
    }

    [Fact]
    public void HttpContext_Null_WhenArgumentNull_HttpRequestException_Unauthorized()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => Throw.Http.Unauthorized.When.Null(argument);

        // Assert
        execution
            .Should()
            .ThrowExactly<HttpRequestException>()
            .WithMessage("Unauthorized: Argument 'argument' must not be null");
    }

    [Fact]
    public void HttpContext_Null_WhenArgumentNull_ThrowsDefaultException_BadRequest()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => Throw.Http.BadRequest.When.Null(argument);

        // Assert
        execution
            .Should()
            .ThrowExactly<HttpRequestException>()
            .WithMessage("BadRequest: Argument 'argument' must not be null");
    }

    [Fact]
    public void HttpContext_Null_WhenArgumentNull_ThrowsDefaultException_NotFound()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => Throw.Http.NotFound.When.Null(argument);

        // Assert
        execution
            .Should()
            .ThrowExactly<HttpRequestException>()
            .WithMessage("NotFound: Argument 'argument' must not be null");
    }

    #endregion
}