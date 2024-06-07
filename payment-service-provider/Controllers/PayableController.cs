using Microsoft.AspNetCore.Mvc;
using payment_service_provider.Dtos;
using payment_service_provider.Services;

namespace payment_service_provider.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PayableController : ControllerBase
{
    private readonly IPayableService _payableService;

    public PayableController(IPayableService payableService)
    {
        _payableService = payableService;
    }

    /// <summary>
    /// List all paid payables
    /// </summary>
    /// <returns>List of paid payables with Value, Status and PaymentDate</returns>
    /// <response code="200">Successfully listed</response>
    [HttpGet("list-paid-payables")]
    public ActionResult<IEnumerable<ReadPayableDto>> ListPaidPayables()
    {
        return Ok(_payableService.ListPaidPayables());
    }

    /// <summary>
    /// List all waiting funds payables
    /// </summary>
    /// <returns>List of waiting funds payables with Value, Status and PaymentDate</returns>
    /// <response code="200">Successfully listed</response>
    [HttpGet("list-waiting-funds-payables")]
    public ActionResult<IEnumerable<ReadPayableDto>> ListWaitingFundsPayables()
    {
        return Ok(_payableService.ListWaitingFundsPayables());
    }

    /// <summary>
    /// Total values of paid and waiting funds payables
    /// </summary>
    /// <returns>Two decimal values with TotalValuePaid and TotalValueWaitingFunds</returns>
    /// <response code="200">Return values with successfully</response>
    [HttpGet("total-values-payables")]
    public ActionResult<ReadTotalValuesPayablesDto> TotalValuesPayables()
    {
        return Ok(_payableService.TotalValuesPayables());
    }
}
