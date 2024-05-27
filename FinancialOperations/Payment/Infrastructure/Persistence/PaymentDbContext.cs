using Microsoft.EntityFrameworkCore;
using FinancialOperations.Payment.Domain.Entities;

namespace FinancialOperations.Payment.Infrastructure.Persistence;

public class PaymentDbContext: DbContext
{
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }

    public DbSet<Domain.Entities.Payment> Payments { get; set; }
}