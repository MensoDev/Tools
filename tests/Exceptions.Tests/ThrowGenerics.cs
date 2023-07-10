namespace Menso.Tools.Exceptions.Tests;

public class ThrowGenerics
{
    [Fact]
    public void ThrowGeneric_ThrowWhenBeNull_Default()
    {
        // Arrange
        string? value = null;

        // Act
        var execution = () => Throw<ApplicationException>.When.BeNull(value);

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
    public void ThrowGeneric_ThrowWhenBeNull_WithInnerException()
    {
        // Arrange
        string? value = null;
        var innerException = new Exception("This is an inner exception");

        // Act
        var execution = () => Throw<ApplicationException>.When.BeNull(value, innerException: innerException);

        // Assert
        execution
            .Should()
            .Throw<ApplicationException>()
            .WithInnerExceptionExactly<Exception>()
            .WithMessage("This is an inner exception");
    }

    [Fact]
    public void ThrowGeneric_ThrowWhenBeNull_WithCustomMessageAndInnerException()
    {
        // Arrange
        string? value = null;
        var innerException = new Exception("This is an inner exception");

        // Act
        var execution = () => Throw<ApplicationException>.When.BeNull(value, "Custom Test", innerException);

        // Assert
        execution
            .Should()
            .Throw<ApplicationException>()
            .WithMessage("Custom Test")
            .WithInnerExceptionExactly<Exception>()
            .WithMessage("This is an inner exception");
    }
}