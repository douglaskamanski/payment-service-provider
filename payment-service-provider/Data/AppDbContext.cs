using Microsoft.EntityFrameworkCore;
using payment_service_provider.Models;

namespace payment_service_provider.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>().ComplexProperty(t => t.Card);
    }

    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Payable> Payables { get; set; }
}
