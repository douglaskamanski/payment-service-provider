using payment_service_provider.Models;

namespace payment_service_provider.Data.Repositories;

public interface IPayableRepository
{
    Task<int> Create(Payable payable);
    Task<IEnumerable<Payable>> ListPaidPayables();
    Task<IEnumerable<Payable>> ListWaitingFundsPayables();
    Task<decimal> TotalValuePaidPayables();
    Task<decimal> TotalValueWaitingFundsPayables();
}
