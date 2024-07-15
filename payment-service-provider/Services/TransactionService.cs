using AutoMapper;
using payment_service_provider.Data.Repositories;
using payment_service_provider.Dtos;
using payment_service_provider.Models;

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

    public async Task<Response<IEnumerable<ReadTransactionDto>>> ListAllTransactions()
    {
        var listAllTransactions = _mapper.Map<List<ReadTransactionDto>>(await _transactionRepository.ListAll());

        Response<IEnumerable<ReadTransactionDto>> response = new()
        {
            Success = true,
            Message = "List all transactions created.",
            Data = listAllTransactions
        };

        return response;
    }
}
