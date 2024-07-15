using Moq;
using payment_service_provider.Data.Repositories;
using payment_service_provider.Domain.Fees;
using payment_service_provider.Models;
using payment_service_provider.Services;
using payment_service_provider.tests.MockData;

namespace payment_service_provider.tests.Services;

public class PaymentServiceTests
{
    [Fact(DisplayName = "Service create payment successfully")]
    public async Task CreatePaymentSuccessfully()
    {
        // Arrange
        var createPaymentDtoMockData = PaymentMockData.CreatePaymentDtoMockData();

        var transactionRepository = new Mock<ITransactionRepository>();
        transactionRepository.Setup(x => x.Create(It.IsAny<Transaction>())).ReturnsAsync(66);

        var payableRepository = new Mock<IPayableRepository>();
        payableRepository.Setup(x => x.Create(It.IsAny<Payable>())).ReturnsAsync(66);

        var computeFee = new Mock<IComputeFee>();

        var sut = new PaymentService(transactionRepository.Object, payableRepository.Object, computeFee.Object);

        // Act
        var result = await sut.CreatePayment(createPaymentDtoMockData);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success && result.Message == "Create payment successfully.");
    }

    [Fact(DisplayName = "Service try create payment with invalid data")]
    public async Task TryCreatePaymentInvalidData()
    {
        // Arrange
        var createPaymentDtoInvalidMockData = PaymentMockData.CreatePaymentDtoInvalidMockData();

        var transactionRepository = new Mock<ITransactionRepository>();
        transactionRepository.Setup(x => x.Create(It.IsAny<Transaction>())).ReturnsAsync(99);

        var payableRepository = new Mock<IPayableRepository>();
        payableRepository.Setup(x => x.Create(It.IsAny<Payable>())).ReturnsAsync(99);

        var computeFee = new Mock<IComputeFee>();

        var sut = new PaymentService(transactionRepository.Object, payableRepository.Object, computeFee.Object);

        // Act
        //var result = Assert.ThrowsAsync<ArgumentException>(() => sut.CreatePayment(createPaymentDtoInvalidMockData));
        var result = await sut.CreatePayment(createPaymentDtoInvalidMockData);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success == false);
        Assert.Equal("Parameter validation exception: Value must be greater than 0,01", result.Message);
    }
}
