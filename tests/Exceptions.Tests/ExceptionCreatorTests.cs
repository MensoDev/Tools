namespace Menso.Tools.Exceptions.Tests;

public class ExceptionCreatorTests
{
    private readonly ExceptionInformation _exceptionInformation = new("Test exception", "Test exception message", "teste");

    private readonly ExceptionInformation _exceptionInformationWithoutCustomMessage = new("Test exception", null, "teste");

    [Fact]
    public void ShouldReturnsArgumentExceptionWhenCreateDefaultExceptionHandleIsNull()
    {
        // Arrange
        ExceptionSettings.CreateDefaultExceptionHandle = null;

        // Act
        var exception = ExceptionCreator.CreateException(_exceptionInformation);

        // Assert
        exception.Should().BeOfType<ArgumentException>();
        
        exception
            .Message
            .Should()
            .Be($"{_exceptionInformation.CustomMessage} (Parameter '{_exceptionInformation.ParamName}')");
        
        ((ArgumentException)exception).ParamName.Should().Be(_exceptionInformation.ParamName);
    }

    [Fact]
    public void ShouldReturnsHttpRequestExceptionWhenCreateDefaultHttpExceptionHandleIsNull()
    {
        // Arrange
        ExceptionSettings.CreateDefaultHttpExceptionHandle = null;

        // Act
        var exception = ExceptionCreator.CreateHttpException(HttpStatusCode.BadRequest, _exceptionInformation);

        // Assert
        exception.Should().BeOfType<HttpRequestException>();
        exception.Message.Should().Be(_exceptionInformation.CustomMessage);
    }

    [Fact]
    public void ShouldReturnsHttpRequestExceptionWithWhenCreateDefaultHttpExceptionHandleIsNullWithDefaultMessage()
    {
        // Arrange
        ExceptionSettings.CreateDefaultHttpExceptionHandle = null;

        // Act
        var exception = ExceptionCreator.CreateHttpException(HttpStatusCode.BadRequest, _exceptionInformationWithoutCustomMessage);

        // Assert
        exception.Should().BeOfType<HttpRequestException>();
        exception.Message.Should().Be("BadRequest: Test exception");
        ((HttpRequestException)exception).StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}