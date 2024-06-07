using payment_service_provider.ValueObjects;

namespace payment_service_provider.tests.ValueObjects;

public class CardTests
{
    [Fact(DisplayName = "Try to insert Card with invalid name")]
    public void ValidateInvalidCardName()
    {
        // Arrange
        string lastFourDigits = "8912";
        string cardName = "DÚARTE LIMA";
        DateTime expirationDate = DateTime.Parse("06/2028");
        string cvv = "8712";

        // Act
        var result = Assert.Throws<ArgumentException>(() => Card.Create(lastFourDigits, cardName, expirationDate, cvv));

        // Assert
        Assert.Equal("Special characters not allowed. (Parameter 'name')", result.Message);
    }
}
