using payment_service_provider.Enums;

namespace payment_service_provider.Dtos;

public class ReadTransactionDto
{
    public decimal Value { get; set; }
    public string Description { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string CardLastFourDigits { get; set; }
    public string CardName { get; set; }
    public DateTime CardExpirationDate { get; set; }
    public string CardCvv { get; set; }
    public DateTime CreatedDate { get; set; }
}
