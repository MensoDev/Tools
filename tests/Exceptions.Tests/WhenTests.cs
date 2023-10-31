namespace Menso.Tools.Exceptions.Tests;

public class WhenTests
{
    private readonly Exception _innerException = new("inner exception");
    private readonly IWhen _when = new When(info => new ArgumentException(info.DefaultMessage, info.ParamName, info.InnerException));

    #region Generic Types

    [Fact]
    public void Null_WhenArgumentIsNull_ThrowsException()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => _when.Null(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null (Parameter 'argument')");
    }

    [Fact]
    public void Null_WhenArgumentIsNull_ThrowsException_WithInnerException()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => _when.Null(argument, innerException: _innerException);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null (Parameter 'argument')")
            .WithInnerExceptionExactly<Exception>();
    }

    [Fact]
    public void Null_WhenArgumentIsNotNull_DoesNotThrowException()
    {
        // Arrange
        object argument = new();

        // Act
        var execution = () => _when.Null(argument);

        // Assert
        execution.Should().NotThrow();
    }

    [Fact]
    public void NotNull_WhenArgumentIsNotNull_ThrowsException()
    {
        // Arrange
        object argument = new();

        // Act
        var execution = () => _when.NotNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be null (Parameter 'argument')");
    }

    [Fact]
    public void NotNull_WhenArgumentIsNotNull_ThrowsException_WithInnerException()
    {
        // Arrange
        object argument = new();

        // Act
        var execution = () => _when.NotNull(argument, innerException: _innerException);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be null (Parameter 'argument')")
            .WithInnerExceptionExactly<Exception>();
    }

    [Fact]
    public void NotNull_WhenArgumentIsNull_DoesNotThrowException()
    {
        // Arrange
        object? argument = null;

        // Act
        var execution = () => _when.NotNull(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    [Fact]
    public void Equal_WhenArgumentsIsEqual_ThrowsException()
    {
        // Arrange
        const int expected = 1;
        const int actual = 1;

        // Act
        var execution = () => _when.Equal(expected, actual);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'actual' must be not equal to '1' (Parameter 'actual')");
    }
    
    [Fact]
    public void Equal_WhenArgumentsIsEqual_ThrowsException_WithInnerException()
    {
        // Arrange
        const int expected = 1;
        const int actual = 1;

        // Act
        var execution = () => _when.Equal(expected, actual, innerException: _innerException);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'actual' must be not equal to '1' (Parameter 'actual')")
            .WithInnerExceptionExactly<Exception>();
    }
    
    [Fact]
    public void Equal_WhenArgumentsIsNotEqual_DoesNotThrowException()
    {
        // Arrange
        const int expected = 1;
        const int actual = 2;

        // Act
        var execution = () => _when.Equal(expected, actual);

        // Assert
        execution.Should().NotThrow();
    }
    
    [Fact]
    public void NotEqual_WhenArgumentsIsNotEqual_ThrowsException()
    {
        // Arrange
        const int expected = 1;
        const int actual = 2;

        // Act
        var execution = () => _when.NotEqual(expected, actual);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'actual' must be equal to '1' (Parameter 'actual')");
    }
    
    [Fact]
    public void NotEqual_WhenArgumentsIsNotEqual_ThrowsException_WithInnerException()
    {
        // Arrange
        const int expected = 1;
        const int actual = 2;

        // Act
        var execution = () => _when.NotEqual(expected, actual, innerException: _innerException);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'actual' must be equal to '1' (Parameter 'actual')")
            .WithInnerExceptionExactly<Exception>();
    }
    
    [Fact]
    public void NotEqual_WhenArgumentsIsEqual_DoesNotThrowException()
    {
        // Arrange
        const int expected = 1;
        const int actual = 1;

        // Act
        var execution = () => _when.NotEqual(expected, actual);

        // Assert
        execution.Should().NotThrow();
    }

    #endregion

    #region String Type

    [Fact]
    public void Empty_WhenStringArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = string.Empty;

        // Act
        var execution = () => _when.Empty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be empty (Parameter 'argument')");
    }

    [Fact]
    public void Empty_WhenStringArgumentIsNotEmpty_DoesNotThrowException()
    {
        // Arrange
        const string argument = "not empty";

        // Act
        var execution = () => _when.Empty(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    [Fact]
    public void NullOrEmpty_WhenStringArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = string.Empty;

        // Act
        var execution = () => _when.NullOrEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }
    
    [Fact]
    public void NullOrEmpty_WhenStringArgumentIsNull_ThrowsException()
    {
        // Arrange
        string argument = null!;

        // Act
        var execution = () => _when.NullOrEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }

    [Fact]
    public void NullOrEmpty_WhenStringArgumentIsNotEmptyOrNull_DoesNotThrowException()
    {
        // Arrange
        const string argument = "not empty";

        // Act
        var execution = () => _when.NullOrEmpty(argument);

        // Assert
        execution.Should().NotThrow();
    }

    [Fact]
    public void NullOrWhiteSpace_WhenStringArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = string.Empty;

        // Act
        var execution = () => _when.NullOrWhiteSpace(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or white space (Parameter 'argument')");
    }
    
    [Fact]
    public void NullOrWhiteSpace_WhenStringArgumentIsNull_ThrowsException()
    {
        // Arrange
        string argument = null!;

        // Act
        var execution = () => _when.NullOrWhiteSpace(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or white space (Parameter 'argument')");
    }

    [Fact]
    public void NullOrWhiteSpace_WhenStringArgumentIsNotEmptyOrNull_DoesNotThrowException()
    {
        // Arrange
        const string argument = "not empty";

        // Act
        var execution = () => _when.NullOrWhiteSpace(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    [Fact]
    public void NotEmpty_WhenStringArgumentIsNotEmpty_ThrowsException()
    {
        // Arrange
        const string argument = "is not empty";

        // Act
        var execution = () => _when.NotEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be empty (Parameter 'argument')");
    }

    [Fact]
    public void NotEmpty_WhenStringArgumentIsEmpty_DoesNotThrowException()
    {
        // Arrange
        var argument = string.Empty;

        // Act
        var execution = () => _when.NotEmpty(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    [Fact]
    public void NotNullOrEmpty_WhenStringArgumentIsNotEmpty_ThrowsException()
    {
        // Arrange
        const string argument = "is not empty";

        // Act
        var execution = () => _when.NotNullOrEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be null or empty (Parameter 'argument')");
    }
    
    [Fact]
    public void NotNullOrEmpty_WhenStringArgumentIsNotNull_ThrowsException()
    {
        // Arrange
        const string argument = "is not null";

        // Act
        var execution = () => _when.NotNullOrEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be null or empty (Parameter 'argument')");
    }

    [Fact]
    public void NotNullOrEmpty_WhenStringArgumentIsEmpty_DoesNotThrowException()
    {
        // Arrange
        var argument = string.Empty;

        // Act
        var execution = () => _when.NotNullOrEmpty(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    [Fact]
    public void NotNullOrEmpty_WhenStringArgumentIsNull_DoesNotThrowException()
    {
        // Arrange
        string argument = null!;

        // Act
        var execution = () => _when.NotNullOrEmpty(argument);

        // Assert
        execution.Should().NotThrow();
    }

    [Fact]
    public void NotNullOrWhiteSpace_WhenStringArgumentIsNotEmpty_ThrowsException()
    {
        // Arrange
        const string argument = "is not empty";

        // Act
        var execution = () => _when.NotNullOrWhiteSpace(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be null or white space (Parameter 'argument')");
    }
    
    [Fact]
    public void NotNullOrWhiteSpace_WhenStringArgumentIsNotNull_ThrowsException()
    {
        // Arrange
        const string argument = "is not null";

        // Act
        var execution = () => _when.NotNullOrWhiteSpace(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be null or white space (Parameter 'argument')");
    }

    [Fact]
    public void NotNullOrWhiteSpace_WhenStringArgumentIsEmpty_DoesNotThrowException()
    {
        // Arrange
        var argument = string.Empty;

        // Act
        var execution = () => _when.NotNullOrWhiteSpace(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    [Fact]
    public void NotNullOrWhiteSpace_WhenStringArgumentIsNull_DoesNotThrowException()
    {
        // Arrange
        string argument = null!;

        // Act
        var execution = () => _when.NotNullOrWhiteSpace(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    #endregion

    #region Enumerable Type

    [Fact]
    public void Empty_WhenEnumerableArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = Enumerable.Empty<object>();

        // Act
        var execution = () => _when.Empty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be empty (Parameter 'argument')");
    }

    [Fact]
    public void Empty_WhenEnumerableArgumentIsNotEmpty_DoesNotThrowException()
    {
        // Arrange
        var argument = new[] { new object() };

        // Act
        var execution = () => _when.Empty(argument);

        // Assert
        execution.Should().NotThrow();
    }
    
    [Fact]
    public void NullOrEmpty_WhenEnumerableArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = Enumerable.Empty<object>();

        // Act
        var execution = () => _when.NullOrEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }
    
    [Fact]
    public void NullOrEmpty_WhenEnumerableArgumentIsNull_ThrowsException()
    {
        // Arrange
        IEnumerable<object> argument = null!;

        // Act
        var execution = () => _when.NullOrEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }

    [Fact]
    public void NullOrEmpty_WhenEnumerableArgumentIsNotEmpty_DoesNotThrowException()
    {
        // Arrange
        var argument = new[] { new object() };

        // Act
        var execution = () => _when.NullOrEmpty(argument);

        // Assert
        execution.Should().NotThrow();
    }

    #endregion
    
    #region Guid Type
    
    [Fact]
    public void Empty_WhenGuidArgumentIsNotEmpty_DoesNotThrowException()
    {
        // Arrange
        var argument = Guid.NewGuid();

        // Act
        var execution = () => _when.Empty(argument);

        // Assert
        execution.Should().NotThrow<ArgumentException>();
    }
    
    [Fact]
    public void Empty_WhenGuidArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = Guid.Empty;

        // Act
        var execution = () => _when.Empty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be empty (Parameter 'argument')");
    }
    
    [Fact]
    public void NullOrEmpty_WhenGuidArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = Guid.Empty;

        // Act
        var execution = () => _when.NullOrEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }
    
    [Fact]
    public void NullOrEmpty_WhenGuidArgumentIsNull_ThrowsException()
    {
        // Arrange
        Guid? argument = null;

        // Act
        var execution = () => _when.NullOrEmpty(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }
    
    [Fact]
    public void EmptyOrNull_WhenGuidArgumentIsNotEmptyOrNull_DoesNotThrowException()
    {
        // Arrange
        var argument = Guid.NewGuid();

        // Act
        var execution = () => _when.NullOrEmpty(argument);

        // Assert
        execution.Should().NotThrow<ArgumentException>();
    }
    
    #endregion
    
    #region Boolean Type
    
    [Fact]
    public void False_WhenBooleanArgumentIsFalse_ThrowsException()
    {
        // Arrange
        const bool argument = false;

        // Act
        var execution = () => _when.False(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be true (Parameter 'argument')");
    }
    
    [Fact]
    public void False_WhenBooleanArgumentIsTrue_DoesNotThrowException()
    {
        // Arrange
        const bool argument = true;

        // Act
        var execution = () => _when.False(argument);

        // Assert
        execution.Should().NotThrow<ArgumentException>();
    }
    
    [Fact]
    public void True_WhenBooleanArgumentIsTrue_ThrowsException()
    {
        // Arrange
        const bool argument = true;

        // Act
        var execution = () => _when.True(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be false (Parameter 'argument')");
    }
    
    [Fact]
    public void True_WhenBooleanArgumentIsFalse_DoesNotThrowException()
    {
        // Arrange
        const bool argument = false;

        // Act
        var execution = () => _when.True(argument);

        // Assert
        execution.Should().NotThrow<ArgumentException>();
    }
    
    [Fact]
    public void NullOrFalse_WhenBooleanArgumentIsFalse_ThrowsException()
    {
        // Arrange
        const bool argument = false;

        // Act
        var execution = () => _when.NullOrFalse(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be true (Parameter 'argument')");
    }
    
    [Fact]
    public void NullOrFalse_WhenBooleanArgumentIsNull_ThrowsException()
    {
        // Arrange
        bool? argument = null!;

        // Act
        var execution = () => _when.NullOrFalse(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must be true (Parameter 'argument')");
    }
    
    [Fact]
    public void NullOrFalse_WhenBooleanArgumentIsTrue_DoesNotThrowException()
    {
        // Arrange
        const bool argument = true;

        // Act
        var execution = () => _when.NullOrFalse(argument);

        // Assert
        execution.Should().NotThrow<ArgumentException>();
    }
    
    #endregion
}