using payment_service_provider.Models;

namespace payment_service_provider.Data.Repositories;

public interface ITransactionRepository
{
    Task<int> Create(Transaction transaction);
    Task<IEnumerable<Transaction>> ListAll();
}
