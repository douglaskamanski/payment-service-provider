using AutoMapper;
using payment_service_provider.Data.Repositories;
using payment_service_provider.Dtos;

namespace payment_service_provider.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public IEnumerable<ReadTransactionDto> ListAllTransactions()
    {
        return _mapper.Map<List<ReadTransactionDto>>(_transactionRepository.ListAll());
    }
}
