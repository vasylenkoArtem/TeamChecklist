using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using TeamChecklist.Domain.Exceptions;
using TeamChecklist.Filters;
using Xunit;

namespace TeamChecklist.UnitTests.WebApi.Filters;

public class ExceptionHandlingMiddlewareTests
{
    private readonly Mock<RequestDelegate> _mockRequestDelegate;
    private readonly Mock<ILogger<ExceptionHandlingMiddleware>> _mockLogger;
    private readonly DefaultHttpContext _httpContext;

    public ExceptionHandlingMiddlewareTests()
    {
        _mockRequestDelegate = new Mock<RequestDelegate>();
        _mockLogger = new Mock<ILogger<ExceptionHandlingMiddleware>>();
        _httpContext = new DefaultHttpContext();
    }

    [Fact]
    public async Task InvokeAsync_DomainExceptionCaught_ReturnsBadRequestWithMessage()
    {
        // Arrange
        var domainException = new DomainException("Domain exception occurred");
        _mockRequestDelegate.Setup(rd => rd(It.IsAny<HttpContext>())).ThrowsAsync(domainException);
        var middleware = new ExceptionHandlingMiddleware(_mockRequestDelegate.Object, _mockLogger.Object);

        _httpContext.Response.Body = new MemoryStream();

        // Act
        await middleware.InvokeAsync(_httpContext);

        // Assert
        _httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
        var responseBody = new StreamReader(_httpContext.Response.Body).ReadToEnd();

        _httpContext.Response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        responseBody.Should().Be(domainException.Message);
    }

    [Fact]
    public async Task InvokeAsync_ExceptionCaught_ReturnsInternalServerError()
    {
        // Arrange
        var exception = new Exception("Unhandled exception occurred");
        _mockRequestDelegate.Setup(rd => rd(It.IsAny<HttpContext>())).ThrowsAsync(exception);
        var middleware = new ExceptionHandlingMiddleware(_mockRequestDelegate.Object, _mockLogger.Object);

        _httpContext.Response.Body = new MemoryStream();

        // Act
        await middleware.InvokeAsync(_httpContext);

        // Assert
        _httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
        var responseBody = new StreamReader(_httpContext.Response.Body).ReadToEnd();

        _httpContext.Response.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        responseBody.Should().Be("An unexpected error occurred.");
    }


    [Fact]
    public async Task InvokeAsync_NoExceptionCaught_CallsNextDelegate()
    {
        // Arrange
        var middleware = new ExceptionHandlingMiddleware(_mockRequestDelegate.Object, _mockLogger.Object);
        bool delegateCalled = false;
        _mockRequestDelegate.Setup(rd => rd(It.IsAny<HttpContext>()))
            .Callback(() => delegateCalled = true)
            .Returns(Task.CompletedTask);

        // Act
        await middleware.InvokeAsync(_httpContext);

        // Assert
        delegateCalled.Should().BeTrue();
    }
}