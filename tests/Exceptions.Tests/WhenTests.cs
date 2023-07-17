namespace Menso.Tools.Exceptions.Tests;

public class WhenTests
{
    private readonly Exception _innerException = new("inner exception");
    private readonly IWhen _when = new When(info => new ArgumentException(info.DefaultMessage, info.ParamName, info.InnerException));

    #region Generic Types

    [Fact]
    public void IsNull_WhenArgumentIsNull_ThrowsException()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => _when.BeNull(argument);

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
        var execution = () => _when.BeNull(argument, innerException: _innerException);

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
        var execution = () => _when.BeNull(argument);

        // Assert
        execution.Should().NotThrow();
    }

    [Fact]
    public void IsNotNull_WhenArgumentIsNotNull_ThrowsException()
    {
        // Arrange
        object argument = new();

        // Act
        var execution = () => _when.BeNotNull(argument);

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
        var execution = () => _when.BeNotNull(argument, innerException: _innerException);

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
        var execution = () => _when.BeNotNull(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    [Fact]
    public void AreEqual_WhenArgumentsAreEqual_ThrowsException()
    {
        // Arrange
        const int expected = 1;
        const int actual = 1;

        // Act
        var execution = () => _when.AreEqual(expected, actual);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'actual' must be not equal to '1' (Parameter 'actual')");
    }
    
    [Fact]
    public void AreEqual_WhenArgumentsAreEqual_ThrowsException_WithInnerException()
    {
        // Arrange
        const int expected = 1;
        const int actual = 1;

        // Act
        var execution = () => _when.AreEqual(expected, actual, innerException: _innerException);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'actual' must be not equal to '1' (Parameter 'actual')")
            .WithInnerExceptionExactly<Exception>();
    }
    
    [Fact]
    public void AreEqual_WhenArgumentsAreNotEqual_DoesNotThrowException()
    {
        // Arrange
        const int expected = 1;
        const int actual = 2;

        // Act
        var execution = () => _when.AreEqual(expected, actual);

        // Assert
        execution.Should().NotThrow();
    }
    
    [Fact]
    public void AreNotEqual_WhenArgumentsAreNotEqual_ThrowsException()
    {
        // Arrange
        const int expected = 1;
        const int actual = 2;

        // Act
        var execution = () => _when.AreNotEqual(expected, actual);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'actual' must be equal to '1' (Parameter 'actual')");
    }
    
    [Fact]
    public void AreNotEqual_WhenArgumentsAreNotEqual_ThrowsException_WithInnerException()
    {
        // Arrange
        const int expected = 1;
        const int actual = 2;

        // Act
        var execution = () => _when.AreNotEqual(expected, actual, innerException: _innerException);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'actual' must be equal to '1' (Parameter 'actual')")
            .WithInnerExceptionExactly<Exception>();
    }
    
    [Fact]
    public void AreNotEqual_WhenArgumentsAreEqual_DoesNotThrowException()
    {
        // Arrange
        const int expected = 1;
        const int actual = 1;

        // Act
        var execution = () => _when.AreNotEqual(expected, actual);

        // Assert
        execution.Should().NotThrow();
    }

    #endregion

    #region String Type

    [Fact]
    public void BeEmpty_WhenStringArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = string.Empty;

        // Act
        var execution = () => _when.BeEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be empty (Parameter 'argument')");
    }

    [Fact]
    public void BeEmpty_WhenStringArgumentIsNotEmpty_DoesNotThrowException()
    {
        // Arrange
        const string argument = "not empty";

        // Act
        var execution = () => _when.BeEmpty(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    [Fact]
    public void BeEmptyOrNull_WhenStringArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = string.Empty;

        // Act
        var execution = () => _when.BeEmptyOrNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }
    
    [Fact]
    public void BeEmptyOrNull_WhenStringArgumentIsNull_ThrowsException()
    {
        // Arrange
        string argument = null!;

        // Act
        var execution = () => _when.BeEmptyOrNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }

    [Fact]
    public void BeEmptyOrNull_WhenStringArgumentIsNotEmptyOrNull_DoesNotThrowException()
    {
        // Arrange
        const string argument = "not empty";

        // Act
        var execution = () => _when.BeEmptyOrNull(argument);

        // Assert
        execution.Should().NotThrow();
    }

    [Fact]
    public void BeNullOrWhiteSpace_WhenStringArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = string.Empty;

        // Act
        var execution = () => _when.BeNullOrWhiteSpace(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or white space (Parameter 'argument')");
    }
    
    [Fact]
    public void BeNullOrWhiteSpace_WhenStringArgumentIsNull_ThrowsException()
    {
        // Arrange
        string argument = null!;

        // Act
        var execution = () => _when.BeNullOrWhiteSpace(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or white space (Parameter 'argument')");
    }

    [Fact]
    public void BeNullOrWhiteSpace_WhenStringArgumentIsNotEmptyOrNull_DoesNotThrowException()
    {
        // Arrange
        const string argument = "not empty";

        // Act
        var execution = () => _when.BeNullOrWhiteSpace(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    #endregion

    #region Enumerable Type

    [Fact]
    public void BeEmpty_WhenEnumerableArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = Enumerable.Empty<object>();

        // Act
        var execution = () => _when.BeEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be empty (Parameter 'argument')");
    }

    [Fact]
    public void BeEmpty_WhenEnumerableArgumentIsNotEmpty_DoesNotThrowException()
    {
        // Arrange
        var argument = new[] { new object() };

        // Act
        var execution = () => _when.BeEmpty(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    [Fact]
    public void BeEmptyOrNull_WhenEnumerableArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = Enumerable.Empty<object>();

        // Act
        var execution = () => _when.BeEmptyOrNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }
    
    [Fact]
    public void BeEmptyOrNull_WhenEnumerableArgumentIsNull_ThrowsException()
    {
        // Arrange
        IEnumerable<object> argument = null!;

        // Act
        var execution = () => _when.BeEmptyOrNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }

    [Fact]
    public void BeEmptyOrNull_WhenEnumerableArgumentIsNotEmpty_DoesNotThrowException()
    {
        // Arrange
        var argument = new[] { new object() };

        // Act
        var execution = () => _when.BeEmptyOrNull(argument);

        // Assert
        execution.Should().NotThrow();
    }

    #endregion
    
    #region Guid Type
    
    [Fact]
    public void BeEmpty_WhenGuidArgumentIsNotEmpty_DoesNotThrowException()
    {
        // Arrange
        var argument = Guid.NewGuid();

        // Act
        var execution = () => _when.BeEmpty(argument);

        // Assert
        execution.Should().NotThrow<ArgumentException>();
    }
    
    [Fact]
    public void BeEmpty_WhenGuidArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = Guid.Empty;

        // Act
        var execution = () => _when.BeEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be empty (Parameter 'argument')");
    }
    
    [Fact]
    public void BeEmptyOrNull_WhenGuidArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = Guid.Empty;

        // Act
        var execution = () => _when.BeEmptyOrNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }
    
    [Fact]
    public void BeEmptyOrNull_WhenGuidArgumentIsNull_ThrowsException()
    {
        // Arrange
        Guid? argument = null;

        // Act
        var execution = () => _when.BeEmptyOrNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }
    
    [Fact]
    public void BeEmptyOrNull_WhenGuidArgumentIsNotEmptyOrNull_DoesNotThrowException()
    {
        // Arrange
        var argument = Guid.NewGuid();

        // Act
        var execution = () => _when.BeEmptyOrNull(argument);

        // Assert
        execution.Should().NotThrow<ArgumentException>();
    }
    
    #endregion
    
    #region Boolean Type
    
    [Fact]
    public void BeFalse_WhenBooleanArgumentIsFalse_ThrowsException()
    {
        // Arrange
        const bool argument = false;

        // Act
        var execution = () => _when.BeFalse(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be true (Parameter 'argument')");
    }
    
    [Fact]
    public void BeFalse_WhenBooleanArgumentIsTrue_DoesNotThrowException()
    {
        // Arrange
        const bool argument = true;

        // Act
        var execution = () => _when.BeFalse(argument);

        // Assert
        execution.Should().NotThrow<ArgumentException>();
    }
    
    [Fact]
    public void BeTrue_WhenBooleanArgumentIsTrue_ThrowsException()
    {
        // Arrange
        const bool argument = true;

        // Act
        var execution = () => _when.BeTrue(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be false (Parameter 'argument')");
    }
    
    [Fact]
    public void BeTrue_WhenBooleanArgumentIsFalse_DoesNotThrowException()
    {
        // Arrange
        const bool argument = false;

        // Act
        var execution = () => _when.BeTrue(argument);

        // Assert
        execution.Should().NotThrow<ArgumentException>();
    }
    
    #endregion
}