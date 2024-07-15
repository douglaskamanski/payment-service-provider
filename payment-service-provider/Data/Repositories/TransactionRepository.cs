using Microsoft.EntityFrameworkCore;
using payment_service_provider.Models;

namespace payment_service_provider.Data.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context)
    {
        _context = context; 
    }

    public async Task<int> Create(Transaction transaction)
    {
        try
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();

            return transaction.Id;
        }
        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Transaction>> ListAll()
    {
        return await _context.Transactions.ToListAsync();
    }
}
