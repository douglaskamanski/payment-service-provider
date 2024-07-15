using payment_service_provider.Dtos;
using payment_service_provider.Models;

namespace payment_service_provider.Services;

public interface IPaymentService
{
    Task<Response<CreatePaymentDto>> CreatePayment(CreatePaymentDto createPaymentDto);
}
