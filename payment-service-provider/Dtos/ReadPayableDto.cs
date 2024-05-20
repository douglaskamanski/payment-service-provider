using payment_service_provider.Enums;

namespace payment_service_provider.Dtos;

public class ReadPayableDto
{
    public decimal Value { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime PaymentDate { get; set; }
}
