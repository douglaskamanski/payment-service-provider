using payment_service_provider.Dtos;
using payment_service_provider.Models;

namespace payment_service_provider.Services;

public interface IPayableService
{
    Task<Response<IEnumerable<ReadPayableDto>>> ListPaidPayables();
    Task<Response<IEnumerable<ReadPayableDto>>> ListWaitingFundsPayables();
    Task<Response<ReadTotalValuesPayablesDto>> TotalValuesPayables();
}
