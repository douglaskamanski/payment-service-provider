using payment_service_provider.Dtos;

namespace payment_service_provider.Services;

public interface ITransactionService
{
    IEnumerable<ReadTransactionDto> ListAllTransactions();
}
