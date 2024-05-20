using payment_service_provider.Dtos;

namespace payment_service_provider.Services;

public interface IPayableService
{
    IEnumerable<ReadPayableDto> ListPaidPayables();
    IEnumerable<ReadPayableDto> ListWaitingFundsPayables();
    ReadTotalValuesPayablesDto TotalValuesPayables();
}
