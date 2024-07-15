using Microsoft.EntityFrameworkCore;
using payment_service_provider.Enums;
using payment_service_provider.Models;

namespace payment_service_provider.Data.Repositories;

public class PayableRepository : IPayableRepository
{
    private readonly AppDbContext _context;

    public PayableRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Create(Payable payable)
    {
        try
        {
            await _context.Payables.AddAsync(payable);
            await _context.SaveChangesAsync();

            return payable.Id;
        }
        catch (DbUpdateException)
        {
            throw;
        }
    }

    public async Task<IEnumerable<Payable>> ListPaidPayables()
    {
        return await _context.Payables.Where(p => p.Status == PaymentStatus.Paid).ToListAsync();
    }

    public async Task<IEnumerable<Payable>> ListWaitingFundsPayables()
    {
        return await _context.Payables.Where(p => p.Status == PaymentStatus.WaitingFunds).ToListAsync();
    }

    public async Task<decimal> TotalValuePaidPayables()
    {
        return await _context.Payables.Where(p => p.Status == PaymentStatus.Paid).SumAsync(p => p.Value);
    }

    public async Task<decimal> TotalValueWaitingFundsPayables()
    {
        return await _context.Payables.Where(p => p.Status == PaymentStatus.WaitingFunds).SumAsync(p => p.Value);
    }
}
