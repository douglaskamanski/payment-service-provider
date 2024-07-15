using Microsoft.AspNetCore.Mvc;
using Moq;
using payment_service_provider.Controllers;
using payment_service_provider.Dtos;
using payment_service_provider.Models;
using payment_service_provider.Services;
using payment_service_provider.tests.MockData;

namespace payment_service_provider.tests.Controllers;

public class PaymentControllerTests
{
    [Fact(DisplayName = "Controller create payment successfully")]
    public async Task Post_PaymentSuccessfullyCreated()
    {
        // Arrange
        var createPaymentDtoMockData = PaymentMockData.CreatePaymentDtoMockData();
        var responseCreatePaymentDtoMockData = PaymentMockData.ResponseCreatePaymentDtoMockData();

        var paymentService = new Mock<IPaymentService>();
        paymentService.Setup(x => x.CreatePayment(It.IsAny<CreatePaymentDto>())).ReturnsAsync(responseCreatePaymentDtoMockData);

        var sut = new PaymentController(paymentService.Object);

        // Act
        var result = await sut.Payment(createPaymentDtoMockData);

        // Assert
        Assert.IsType<ActionResult<Response<CreatePaymentDto>>>(result);
    }
}
