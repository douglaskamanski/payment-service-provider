using payment_service_provider.Models;

namespace payment_service_provider.Data.Repositories;

public interface IPayableRepository
{
    bool Create(Payable payable);
    IEnumerable<Payable> ListPaidPayables();
    IEnumerable<Payable> ListWaitingFundsPayables();
    decimal TotalValuePaidPayables();
    decimal TotalValueWaitingFundsPayables();
}
