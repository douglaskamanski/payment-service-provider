using Moq;
using AutoMapper;
using payment_service_provider.Data.Repositories;
using payment_service_provider.tests.MockData;
using payment_service_provider.Profiles;
using payment_service_provider.Services;
using payment_service_provider.Models;
using payment_service_provider.Dtos;

namespace payment_service_provider.tests.Services;

public class PayableServiceTests
{
    [Fact(DisplayName = "Service list paid payables")]
    public async Task ListPaidPayablesSuccessfully()
    {
        // Arrange
        var listPaidPayablesMockData = PayableMockData.ListPaidPayablesMockData;

        var payablesRepository = new Mock<IPayableRepository>();
        payablesRepository.Setup(x => x.ListPaidPayables()).ReturnsAsync(listPaidPayablesMockData);

        var autoMapperProfile = new PayableProfile();
        var autoMapperConfig = new MapperConfiguration(x => x.AddProfile(autoMapperProfile));
        IMapper autoMapper = new Mapper(autoMapperConfig);

        var sut = new PayableService(payablesRepository.Object, autoMapper);

        // Act
        var result = await sut.ListPaidPayables();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Data.Any());
    }

    [Fact(DisplayName = "Service list waiting funds payables")]
    public async Task ListWaitingFundsPayablesSuccessfully()
    {
        // Arrange
        var listWaitingFundsPayablesMockData = PayableMockData.ListWaitingFundsPayablesMockData;

        var payablesRepository = new Mock<IPayableRepository>();
        payablesRepository.Setup(x => x.ListWaitingFundsPayables()).ReturnsAsync(listWaitingFundsPayablesMockData);

        var autoMapperProfile = new PayableProfile();
        var autoMapperConfig = new MapperConfiguration(x => x.AddProfile(autoMapperProfile));
        IMapper autoMapper = new Mapper(autoMapperConfig);

        var sut = new PayableService(payablesRepository.Object, autoMapper);

        // Act
        var result = await sut.ListWaitingFundsPayables();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Data.Any());
    }

    [Fact(DisplayName = "Service return total values payables")]
    public async Task TotalValuesPayablesSuccessfully()
    {
        // Arrange
        var totalValuePaidPayablesMockData = PayableMockData.TotalValuePaidPayablesMockData;
        var totalValueWaitingFundsPayablesMockData = PayableMockData.TotalValueWaitingFundsPayablesMockData;

        var autoMapper = new Mock<IMapper>();

        var payablesRepository = new Mock<IPayableRepository>();
        payablesRepository.Setup(x => x.TotalValuePaidPayables()).ReturnsAsync(totalValuePaidPayablesMockData);
        payablesRepository.Setup(x => x.TotalValueWaitingFundsPayables()).ReturnsAsync(totalValueWaitingFundsPayablesMockData);

        var sut = new PayableService(payablesRepository.Object, autoMapper.Object);

        // Act
        var result = await sut.TotalValuesPayables();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Data.TotalValuePaid > 0 && result.Data.TotalValueWaitingFunds > 0);
    }
}
