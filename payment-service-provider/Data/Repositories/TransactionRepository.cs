using payment_service_provider.Models;

namespace payment_service_provider.Data.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context)
    {
        _context = context; 
    }

    public void Create(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        _context.SaveChanges();
    }

    public IEnumerable<Transaction> ListAll()
    {
        return _context.Transactions.ToList();
    }
}
