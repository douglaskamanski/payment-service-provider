using Microsoft.AspNetCore.Mvc;
using Moq;
using payment_service_provider.Controllers;
using payment_service_provider.Dtos;
using payment_service_provider.Services;
using payment_service_provider.tests.MockData;

namespace payment_service_provider.tests.Controllers;

public class PayableControllerTests
{
    [Fact(DisplayName = "Controller list paid payables and returning ActionResult<IEnumerable<ReadPayableDto>>")]
    public void Get_ListPaidPayablesSuccessfully()
    {
        // Arrange
        var listPaidPayablesMockData = PayableMockData.ListPaidPayablesDtoMockData;

        var payableService = new Mock<IPayableService>();
        payableService.Setup(x => x.ListPaidPayables()).Returns(listPaidPayablesMockData);

        var sut = new PayableController(payableService.Object);

        // Act
        var result = sut.ListPaidPayables();

        // Assert
        Assert.IsType<ActionResult<IEnumerable<ReadPayableDto>>>(result);
    }

    [Fact(DisplayName = "Controller list waiting funds payables and returning ActionResult<IEnumerable<ReadPayableDto>>")]
    public void Get_ListWaitingFundsPayablesSuccessfully()
    {
        // Arrange
        var listWaitingFundsPayablesMockData = PayableMockData.ListWaitingFundsPayablesDtoMockData;

        var payableService = new Mock<IPayableService>();
        payableService.Setup(x => x.ListWaitingFundsPayables()).Returns(listWaitingFundsPayablesMockData);

        var sut = new PayableController(payableService.Object);

        // Act
        var result = sut.ListWaitingFundsPayables();

        // Assert
        Assert.IsType<ActionResult<IEnumerable<ReadPayableDto>>>(result);
    }

    [Fact(DisplayName = "Controller get total values payables and returning ActionResult<ReadTotalValuesPayablesDto>")]
    public void Get_TotalValuesPayablesSuccessfully()
    {
        // Arrange
        var totalValuesPayablesMockData = PayableMockData.TotalValuesPayablesDtoMockData;

        var payableService = new Mock<IPayableService>();
        payableService.Setup(x => x.TotalValuesPayables()).Returns(totalValuesPayablesMockData);

        var sut = new PayableController(payableService.Object);

        // Act
        var result = sut.TotalValuesPayables();

        // Assert
        Assert.IsType<ActionResult<ReadTotalValuesPayablesDto>>(result);
    }
}
