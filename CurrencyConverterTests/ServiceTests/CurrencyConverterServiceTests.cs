// CurrencyConverterServiceTests.cs
using CurrencyConverterApp;
using CurrencyConverterApp.Services;
using Xunit;

public class CurrencyConverterServiceTests
{
    [Fact]
    public void ConvertCurrency_ValidInput_ReturnsResult()
    {
        // Arrange
        var service = new CurrencyConverterService();
        var amount = "123.45";

        // Act
        var result = service.ConvertCurrencyToWords(amount);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(result, "one hundred twenty-three dollars and forty-five cents");
    }

}
