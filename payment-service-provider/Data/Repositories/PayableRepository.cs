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

    public void Create(Payable payable)
    {
        _context.Payables.Add(payable);
        _context.SaveChanges();
    }

    public IEnumerable<Payable> ListPaidPayables()
    {
        return _context.Payables.Where(p => p.Status == PaymentStatus.Paid).ToList();
    }

    public IEnumerable<Payable> ListWaitingFundsPayables()
    {
        return _context.Payables.Where(p => p.Status == PaymentStatus.WaitingFunds).ToList();
    }

    public decimal TotalValuePaidPayables()
    {
        return _context.Payables.Where(p => p.Status == PaymentStatus.Paid).Sum(p => p.Value);
    }

    public decimal TotalValueWaitingFundsPayables()
    {
        return _context.Payables.Where(p => p.Status == PaymentStatus.WaitingFunds).Sum(p => p.Value);
    }
}
