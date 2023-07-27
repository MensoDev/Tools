﻿namespace Menso.Tools.Exceptions.Tests;

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
    public void EmptyOrNull_WhenStringArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = string.Empty;

        // Act
        var execution = () => _when.EmptyOrNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }
    
    [Fact]
    public void EmptyOrNull_WhenStringArgumentIsNull_ThrowsException()
    {
        // Arrange
        string argument = null!;

        // Act
        var execution = () => _when.EmptyOrNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }

    [Fact]
    public void EmptyOrNull_WhenStringArgumentIsNotEmptyOrNull_DoesNotThrowException()
    {
        // Arrange
        const string argument = "not empty";

        // Act
        var execution = () => _when.EmptyOrNull(argument);

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
    public void EmptyOrNull_WhenEnumerableArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = Enumerable.Empty<object>();

        // Act
        var execution = () => _when.EmptyOrNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }
    
    [Fact]
    public void EmptyOrNull_WhenEnumerableArgumentIsNull_ThrowsException()
    {
        // Arrange
        IEnumerable<object> argument = null!;

        // Act
        var execution = () => _when.EmptyOrNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }

    [Fact]
    public void EmptyOrNull_WhenEnumerableArgumentIsNotEmpty_DoesNotThrowException()
    {
        // Arrange
        var argument = new[] { new object() };

        // Act
        var execution = () => _when.EmptyOrNull(argument);

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
    public void EmptyOrNull_WhenGuidArgumentIsEmpty_ThrowsException()
    {
        // Arrange
        var argument = Guid.Empty;

        // Act
        var execution = () => _when.EmptyOrNull(argument);

        // Assert
        execution
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Argument 'argument' must not be null or empty (Parameter 'argument')");
    }
    
    [Fact]
    public void EmptyOrNull_WhenGuidArgumentIsNull_ThrowsException()
    {
        // Arrange
        Guid? argument = null;

        // Act
        var execution = () => _when.EmptyOrNull(argument);

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
        var execution = () => _when.EmptyOrNull(argument);

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
    
    #endregion
}