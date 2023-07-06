namespace Menso.Tools.Exceptions.Tests;

public class WhenTests
{
    private readonly IWhen _when = new When(info => new ArgumentException(info.DefaultMessage, info.ParamName, info.InnerException));
    private readonly Exception _innerException = new("inner exception");

    #region Generic Types

    [Fact]
    public void IsNull_WhenArgumentIsNull_ThrowsException()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => _when.IsNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null (Parameter 'argument')");
    }
    
    [Fact]
    public void IsNull_WhenArgumentIsNull_ThrowsException_WithInnerException()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => _when.IsNull(argument, innerException: _innerException);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null (Parameter 'argument')")
            .WithInnerExceptionExactly<Exception>();
    }

    [Fact]
    public void IsNull_WhenArgumentIsNotNull_DoesNotThrowException()
    {
        // Arrange
        object argument = new();

        // Act
        var execution = () => _when.IsNull(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    [Fact]
    public void IsNotNull_WhenArgumentIsNotNull_ThrowsException()
    {
        // Arrange
        object argument = new();

        // Act
        var execution = () => _when.IsNotNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be null (Parameter 'argument')");
    }
    
    [Fact]
    public void IsNotNull_WhenArgumentIsNotNull_ThrowsException_WithInnerException()
    {
        // Arrange
        object argument = new();

        // Act
        var execution = () => _when.IsNotNull(argument, innerException: _innerException);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be null (Parameter 'argument')")
            .WithInnerExceptionExactly<Exception>();
    }

    [Fact]
    public void IsNotNull_WhenArgumentIsNull_DoesNotThrowException()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => _when.IsNotNull(argument);

        // Assert
        execution.Should().NotThrow();
    }

    #endregion

    #region String Type

    [Fact]
    public void IsEmpty_WhenStringArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = string.Empty;

        // Act
        var execution = () => _when.IsEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be empty (Parameter 'argument')");
    }

    [Fact]
    public void IsEmpty_WhenStringArgumentIsNotEmpty_DoesNotThrowException()
    {
        // Arrange
        const string argument = "not empty";

        // Act
        var execution = () => _when.IsEmpty(argument);

        // Assert
        execution.Should().NotThrow();
    }

    #endregion

    #region Enumerable Type

    [Fact]
    public void IsEmpty_WhenEnumerableArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = Enumerable.Empty<object>();

        // Act
        var execution = () => _when.IsEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be empty (Parameter 'argument')");
    }

    [Fact]
    public void IsEmpty_WhenEnumerableArgumentIsNotEmpty_DoesNotThrowException()
    {
        // Arrange
        var argument = new[] { new object() };

        // Act
        var execution = () => _when.IsEmpty(argument);

        // Assert
        execution.Should().NotThrow();
    }

    #endregion
}