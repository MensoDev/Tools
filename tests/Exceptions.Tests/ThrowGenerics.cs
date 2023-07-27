namespace Menso.Tools.Exceptions.Tests;

public class ThrowGenerics
{
    [Fact]
    public void ThrowGeneric_ThrowWhenNull_Default()
    {
        // Arrange
        string? value = null;

        // Act
        var execution = () => Throw<ApplicationException>.When.Null(value);

        // Assert
        execution
            .Should()
            .Throw<ApplicationException>()
            .And
            .InnerException
            .Should()
            .BeNull();
    }

    [Fact]
    public void ThrowGeneric_ThrowWhenNull_WithInnerException()
    {
        // Arrange
        string? value = null;
        var innerException = new Exception("This is an inner exception");

        // Act
        var execution = () => Throw<ApplicationException>.When.Null(value, innerException: innerException);

        // Assert
        execution
            .Should()
            .Throw<ApplicationException>()
            .WithInnerExceptionExactly<Exception>()
            .WithMessage("This is an inner exception");
    }

    [Fact]
    public void ThrowGeneric_ThrowWhenNull_WithCustomMessageAndInnerException()
    {
        // Arrange
        string? value = null;
        var innerException = new Exception("This is an inner exception");

        // Act
        var execution = () => Throw<ApplicationException>.When.Null(value, "Custom Test", innerException);

        // Assert
        execution
            .Should()
            .Throw<ApplicationException>()
            .WithMessage("Custom Test")
            .WithInnerExceptionExactly<Exception>()
            .WithMessage("This is an inner exception");
    }
}