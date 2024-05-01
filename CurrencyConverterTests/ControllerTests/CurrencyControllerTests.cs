using CurrencyConverterApp;
using CurrencyConverterApp.Controllers;
using CurrencyConverterApp.Models;
using CurrencyConverterApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class CurrencyControllerTests
{
    [Fact]
    public void ConvertCurrency_ValidInput_ReturnsOkResult()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<CurrencyController>>();
        var converterServiceMock = new Mock<CurrencyConverterService>();
        var controller = new CurrencyController(loggerMock.Object, converterServiceMock.Object);
        var input = new CurrencyInput { Amount = "123.45" }; 

        // Act
        var result = controller.ConvertCurrency(input);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }
}