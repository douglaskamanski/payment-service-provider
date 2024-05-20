using payment_service_provider.Dtos;

namespace payment_service_provider.Services;

public interface IPaymentService
{
    void CreatePayment(CreatePaymentDto createPaymentDto);
}
