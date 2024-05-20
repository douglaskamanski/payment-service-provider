using Microsoft.AspNetCore.Mvc;
using payment_service_provider.Dtos;
using payment_service_provider.Services;

namespace payment_service_provider.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    /// <summary>
    /// Create payment
    /// </summary>
    /// <param name="createPaymentDto">value - transaction value, description - transaction description, paymentMethod - payment method, cardNumbers - card numbers, cardName - card carrier name, cardExpirationDate - card expiration date and cardCvv - card verification value (CVV)</param>
    /// <response code="204">Successfully created</response>
    [HttpPost("payment")]
    public IActionResult Payment(CreatePaymentDto createPaymentDto)
    {
        _paymentService.CreatePayment(createPaymentDto);

        return Created();
    }
}
