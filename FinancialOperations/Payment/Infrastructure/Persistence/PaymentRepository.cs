using FinancialOperations.Payment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancialOperations.Payment.Infrastructure.Persistence;

public class PaymentRepository : IPaymentRepository
{
    private readonly PaymentDbContext _context;

    public PaymentRepository(PaymentDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Domain.Entities.Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Domain.Entities.Payment> GetPaymentAsync(int id)
    {
        return await _context.Payments.FindAsync(id);
    }

    public async Task<IEnumerable<Domain.Entities.Payment>> GetAllPaymentsAsync()
    {
        return await _context.Payments.ToListAsync();
    }

    public async Task UpdatePaymentAsync(Domain.Entities.Payment payment)
    {
        _context.Entry(payment).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}