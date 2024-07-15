using Microsoft.AspNetCore.Mvc;
using payment_service_provider.Dtos;
using payment_service_provider.Models;
using payment_service_provider.Services;

namespace payment_service_provider.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    /// <summary>
    /// List all transactions created
    /// </summary>
    /// <returns>List of transactions with Value, Description, PaymentMethod, CardLastFourDigits, CardName, CardExpirationDate, CardCvv and CreatedDate</returns>
    /// <response code="200">Successfully listed</response>
    [HttpGet("list-all-transactions")]
    public async Task<ActionResult<Response<IEnumerable<ReadTransactionDto>>>> ListAllTransactions()
    {
        var response = await _transactionService.ListAllTransactions();

        return Ok(response);
    }
}
