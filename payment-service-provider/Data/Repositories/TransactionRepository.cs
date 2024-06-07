using payment_service_provider.Models;

namespace payment_service_provider.Data.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context)
    {
        _context = context; 
    }

    public bool Create(Transaction transaction)
    {
        try
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Create transaction failed: {ex.Message}");
        }
    }

    public IEnumerable<Transaction> ListAll()
    {
        return _context.Transactions.ToList();
    }
}
