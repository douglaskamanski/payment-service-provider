using payment_service_provider.Models;

namespace payment_service_provider.Data.Repositories;

public interface ITransactionRepository
{
    bool Create(Transaction transaction);
    IEnumerable<Transaction> ListAll();
}
