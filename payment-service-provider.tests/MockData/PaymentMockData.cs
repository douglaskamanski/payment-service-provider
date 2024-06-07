using payment_service_provider.Dtos;

namespace payment_service_provider.tests.MockData;

public class PaymentMockData
{
    public static CreatePaymentDto CreatePaymentDtoMockData()
    {
        return new CreatePaymentDto()
        {
            Value = 650.75m,
            Description = "Compra Supermercado do Povo",
            PaymentMethod = Enums.PaymentMethod.DebitCard,
            CardNumbers = "9782612022054528",
            CardName = "JOSE ALIRIO",
            CardExpirationDate = DateTime.Parse("11/2027"),
            CardCvv = "520"
        };
    }

    public static CreatePaymentDto CreatePaymentDtoInvalidMockData()
    {
        return new CreatePaymentDto()
        {
            Description = "Compra Supermercado do Povo",
            PaymentMethod = Enums.PaymentMethod.DebitCard,
            CardNumbers = "9782612022054528",
            CardName = "JOSE ALIRIO",
            CardExpirationDate = DateTime.Parse("11/2027"),
            CardCvv = "520"
        };
    }
}
