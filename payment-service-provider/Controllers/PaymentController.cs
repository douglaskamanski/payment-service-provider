using Microsoft.AspNetCore.Mvc;
using payment_service_provider.Dtos;
using payment_service_provider.Models;
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
    /// <param name="createPaymentDto">value - transaction value, description - transaction description, paymentMethod - payment method: 0 - debit card 1 - credit card, cardNumbers - card numbers, cardName - card carrier name, cardExpirationDate - card expiration date: AAAA-MM-DD and card Cvv - card verification value (CVV)</param>
    /// <response code="200">Create payment successfully</response>
    [HttpPost("payment")]
    public async Task<ActionResult<Response<CreatePaymentDto>>> Payment(CreatePaymentDto createPaymentDto)
    {
        Response<CreatePaymentDto> response = new();

        if (!ModelState.IsValid)
        {
            response.Success = false;
            response.Message = "Model state is invalid.";
            response.Data = createPaymentDto;

            return Ok(response);
        }

        response = await _paymentService.CreatePayment(createPaymentDto);

        return Ok(response);
    }
}
