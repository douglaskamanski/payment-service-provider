using Moq;
using payment_service_provider.Data.Repositories;
using payment_service_provider.Domain.Fees;
using payment_service_provider.Models;
using payment_service_provider.Services;
using payment_service_provider.tests.MockData;

namespace payment_service_provider.tests.Services;

public class PaymentServiceTests
{
    [Fact(DisplayName = "Service create payment Successfully")]
    public void CreatePaymentSuccessfully()
    {
        // Arrange
        var createPaymentDtoMockData = PaymentMockData.CreatePaymentDtoMockData();

        var transactionRepository = new Mock<ITransactionRepository>();
        transactionRepository.Setup(x => x.Create(It.IsAny<Transaction>())).Returns(true);

        var payableRepository = new Mock<IPayableRepository>();
        payableRepository.Setup(x => x.Create(It.IsAny<Payable>())).Returns(true);

        var computeFee = new Mock<IComputeFee>();

        var sut = new PaymentService(transactionRepository.Object, payableRepository.Object, computeFee.Object);

        // Act
        var result = sut.CreatePayment(createPaymentDtoMockData);

        // Assert
        Assert.True(result);
    }

    [Fact(DisplayName = "Service try create payment with invalid data")]
    public void TryCreatePaymentInvalidData()
    {
        // Arrange
        var createPaymentDtoInvalidMockData = PaymentMockData.CreatePaymentDtoInvalidMockData();

        var transactionRepository = new Mock<ITransactionRepository>();
        transactionRepository.Setup(x => x.Create(It.IsAny<Transaction>())).Returns(true);

        var payableRepository = new Mock<IPayableRepository>();
        payableRepository.Setup(x => x.Create(It.IsAny<Payable>())).Returns(true);

        var computeFee = new Mock<IComputeFee>();

        var sut = new PaymentService(transactionRepository.Object, payableRepository.Object, computeFee.Object);

        // Act
        var result = Assert.Throws<ArgumentException>(() => sut.CreatePayment(createPaymentDtoInvalidMockData));

        // Assert
        Assert.Equal("Value must be greater than 0,01 (Parameter 'createPaymentDto')", result.Message);
    }
}
