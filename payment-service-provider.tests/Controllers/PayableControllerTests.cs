using Microsoft.AspNetCore.Mvc;
using Moq;
using payment_service_provider.Controllers;
using payment_service_provider.Dtos;
using payment_service_provider.Models;
using payment_service_provider.Services;
using payment_service_provider.tests.MockData;

namespace payment_service_provider.tests.Controllers;

public class PayableControllerTests
{
    [Fact(DisplayName = "Controller list paid payables and returning ActionResult<Response<IEnumerable<ReadPayableDto>>>")]
    public async Task Get_ListPaidPayablesSuccessfully()
    {
        // Arrange
        var listPaidPayablesMockData = PayableMockData.ListPaidPayablesDtoMockData;

        var payableService = new Mock<IPayableService>();
        payableService.Setup(x => x.ListPaidPayables()).ReturnsAsync(listPaidPayablesMockData);

        var sut = new PayableController(payableService.Object);

        // Act
        var result = await sut.ListPaidPayables();

        // Assert
        Assert.IsType<ActionResult<Response<IEnumerable<ReadPayableDto>>>>(result);
    }

    [Fact(DisplayName = "Controller list waiting funds payables and returning ActionResult<IEnumerable<ReadPayableDto>>")]
    public async Task Get_ListWaitingFundsPayablesSuccessfully()
    {
        // Arrange
        var listWaitingFundsPayablesMockData = PayableMockData.ListWaitingFundsPayablesDtoMockData;

        var payableService = new Mock<IPayableService>();
        payableService.Setup(x => x.ListWaitingFundsPayables()).ReturnsAsync(listWaitingFundsPayablesMockData);

        var sut = new PayableController(payableService.Object);

        // Act
        var result = await sut.ListWaitingFundsPayables();

        // Assert
        Assert.IsType<ActionResult<Response<IEnumerable<ReadPayableDto>>>>(result);
    }

    [Fact(DisplayName = "Controller get total values payables and returning ActionResult<ReadTotalValuesPayablesDto>")]
    public async Task Get_TotalValuesPayablesSuccessfully()
    {
        // Arrange
        var totalValuesPayablesMockData = PayableMockData.TotalValuesPayablesDtoMockData;

        var payableService = new Mock<IPayableService>();
        payableService.Setup(x => x.TotalValuesPayables()).ReturnsAsync(totalValuesPayablesMockData);

        var sut = new PayableController(payableService.Object);

        // Act
        var result = await sut.TotalValuesPayables();

        // Assert
        Assert.IsType<ActionResult<Response<ReadTotalValuesPayablesDto>>>(result);
    }
}
