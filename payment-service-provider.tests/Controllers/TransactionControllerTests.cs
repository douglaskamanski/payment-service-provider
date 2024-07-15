using Microsoft.AspNetCore.Mvc;
using Moq;
using payment_service_provider.Controllers;
using payment_service_provider.Dtos;
using payment_service_provider.Models;
using payment_service_provider.Services;
using payment_service_provider.tests.MockData;

namespace payment_service_provider.tests.Controllers;

public class TransactionControllerTests
{
    [Fact(DisplayName = "Controller list all transactions and return ActionResult<IEnumerable<ReadTransactionDto>>")]
    public async Task Get_ListAllTransactions()
    {
        // Arrange
        var listAllTransactionsDtoMockData = TransactionMockData.ListAllTransactionsDtoMockData();

        var transactionService = new Mock<ITransactionService>();
        transactionService.Setup(x => x.ListAllTransactions()).ReturnsAsync(listAllTransactionsDtoMockData);

        var sut = new TransactionController(transactionService.Object);

        // Act
        var result = await sut.ListAllTransactions();

        // Assert
        Assert.IsType<ActionResult<Response<IEnumerable<ReadTransactionDto>>>>(result);
    }
}
