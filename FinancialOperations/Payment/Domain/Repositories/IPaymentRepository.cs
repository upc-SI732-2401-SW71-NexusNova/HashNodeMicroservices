using System.Threading.Tasks;

namespace FinancialOperations.Payment.Domain.Repositories;

public interface IPaymentRepository
{
    Task AddAsync(Entities.Payment payment);
    Task<Entities.Payment> GetPaymentAsync(int id);
    Task<IEnumerable<Entities.Payment>> GetAllPaymentsAsync();
    Task UpdatePaymentAsync(Entities.Payment payment);
}