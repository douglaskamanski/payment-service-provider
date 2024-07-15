using Moq;
using AutoMapper;
using payment_service_provider.Data.Repositories;
using payment_service_provider.Profiles;
using payment_service_provider.Services;
using payment_service_provider.tests.MockData;

namespace payment_service_provider.tests.Services;

public class TransactionServiceTests
{   
    [Fact(DisplayName = "Service list all transactions")]
    public async Task ListAllTransactionsSuccessfully()
    {
        // Arrange
        var listAllTransactionMockData = TransactionMockData.ListAllTransactionsMockData();

        var transactionRepository = new Mock<ITransactionRepository>();
        transactionRepository.Setup(x => x.ListAll()).ReturnsAsync(listAllTransactionMockData);

        var autoMapperProfile = new TransactionProfile();
        var autoMapperConfig = new MapperConfiguration(x => x.AddProfile(autoMapperProfile));
        IMapper autoMapper = new Mapper(autoMapperConfig);

        var sut = new TransactionService(transactionRepository.Object, autoMapper);

        // Act
        var result = await sut.ListAllTransactions();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Data.Any());
    }
}
