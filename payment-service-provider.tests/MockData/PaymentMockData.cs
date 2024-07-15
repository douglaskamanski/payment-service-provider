using Microsoft.AspNetCore.Http.HttpResults;
using payment_service_provider.Dtos;
using payment_service_provider.Models;

namespace payment_service_provider.tests.MockData;

public class PaymentMockData
{
    public static CreatePaymentDto CreatePaymentDtoMockData()
    {
        return new()
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

    public static Response<CreatePaymentDto> ResponseCreatePaymentDtoMockData()
    {
        return new()
        {
            Success = true,
            Message = "Create payment successfully.",
            Data = null
        };
    }

    public static CreatePaymentDto CreatePaymentDtoInvalidMockData()
    {
        return new()
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
