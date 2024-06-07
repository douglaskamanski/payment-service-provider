using Moq;
using AutoMapper;
using payment_service_provider.Data.Repositories;
using payment_service_provider.tests.MockData;
using payment_service_provider.Profiles;
using payment_service_provider.Services;

namespace payment_service_provider.tests.Services;

public class PayableServiceTests
{
    [Fact(DisplayName = "Service list paid payables")]
    public void ListPaidPayablesSuccessfully()
    {
        // Arrange
        var listPaidPayablesMockData = PayableMockData.ListPaidPayablesMockData;

        var payablesRepository = new Mock<IPayableRepository>();
        payablesRepository.Setup(x => x.ListPaidPayables()).Returns(listPaidPayablesMockData);

        var autoMapperProfile = new PayableProfile();
        var autoMapperConfig = new MapperConfiguration(x => x.AddProfile(autoMapperProfile));
        IMapper autoMapper = new Mapper(autoMapperConfig);

        var sut = new PayableService(payablesRepository.Object, autoMapper);

        // Act
        var result = sut.ListPaidPayables();

        // Assert
        Assert.True(result.Count() > 0);
    }

    [Fact(DisplayName = "Service list waiting funds payables")]
    public void ListWaitingFundsPayablesSuccessfully()
    {
        // Arrange
        var listWaitingFundsPayablesMockData = PayableMockData.ListWaitingFundsPayablesMockData;

        var payablesRepository = new Mock<IPayableRepository>();
        payablesRepository.Setup(x => x.ListWaitingFundsPayables()).Returns(listWaitingFundsPayablesMockData);

        var autoMapperProfile = new PayableProfile();
        var autoMapperConfig = new MapperConfiguration(x => x.AddProfile(autoMapperProfile));
        IMapper autoMapper = new Mapper(autoMapperConfig);

        var sut = new PayableService(payablesRepository.Object, autoMapper);

        // Act
        var result = sut.ListWaitingFundsPayables();

        // Assert
        Assert.True(result.Count() > 0);
    }

    [Fact(DisplayName = "Service return total values payables")]
    public void TotalValuesPayablesSuccessfully()
    {
        // Arrange
        var totalValuePaidPayablesMockData = PayableMockData.TotalValuePaidPayablesMockData;
        var totalValueWaitingFundsPayablesMockData = PayableMockData.TotalValueWaitingFundsPayablesMockData;

        var autoMapper = new Mock<IMapper>();

        var payablesRepository = new Mock<IPayableRepository>();
        payablesRepository.Setup(x => x.TotalValuePaidPayables()).Returns(totalValuePaidPayablesMockData);
        payablesRepository.Setup(x => x.TotalValueWaitingFundsPayables()).Returns(totalValueWaitingFundsPayablesMockData);

        var sut = new PayableService(payablesRepository.Object, autoMapper.Object);

        // Act
        var result = sut.TotalValuesPayables();

        // Assert
        Assert.True(result.TotalValuePaid > 0 && result.TotalValueWaitingFunds > 0);
    }
}
