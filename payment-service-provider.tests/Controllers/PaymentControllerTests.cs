using Microsoft.AspNetCore.Mvc;
using Moq;
using payment_service_provider.Controllers;
using payment_service_provider.Dtos;
using payment_service_provider.Services;
using payment_service_provider.tests.MockData;

namespace payment_service_provider.tests.Controllers;

public class PaymentControllerTests
{
    [Fact(DisplayName = "Controller create payment controller test should return 204 status")]
    public void Post_PaymentSuccessfullyCreated()
    {
        // Arrange
        var createPaymentDtoMockData = PaymentMockData.CreatePaymentDtoMockData();

        var paymentService = new Mock<IPaymentService>();
        paymentService.Setup(x => x.CreatePayment(It.IsAny<CreatePaymentDto>())).Returns(true);

        var sut = new PaymentController(paymentService.Object);

        // Act
        var result = (NoContentResult) sut.Payment(createPaymentDtoMockData);

        // Assert
        Assert.Equal(204, result.StatusCode);
    }
}
