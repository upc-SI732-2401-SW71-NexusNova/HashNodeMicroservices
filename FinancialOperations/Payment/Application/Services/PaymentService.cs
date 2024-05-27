using FinancialOperations.Payment.Domain.Repositories;

namespace FinancialOperations.Payment.Application.Services;

public class PaymentService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<Domain.Entities.Payment> CreatePaymentAsync(float amount, string currency, string cardNumber, string cardCvv)
    {
        var payment = new Domain.Entities.Payment
        {
            Amount = amount,
            Currency = currency,
            CardNumber = cardNumber,
            CardCvv = cardCvv
        };
        await _paymentRepository.AddAsync(payment);
        return payment;
    }
    
    public async Task<Domain.Entities.Payment> GetPaymentAsync(int id)
    {
        return await _paymentRepository.GetPaymentAsync(id);
    }

    public async Task<IEnumerable<Domain.Entities.Payment>> GetAllPaymentsAsync()
    {
        return await _paymentRepository.GetAllPaymentsAsync();
    }
    
    public async Task<Domain.Entities.Payment> UpdatePaymentAsync(int id, float amount, string currency, string cardNumber, string cardCvv)
    {
        var existingPayment = await _paymentRepository.GetPaymentAsync(id);
        if (existingPayment == null)
        {
            return null; 
        }
        existingPayment.Amount = amount;
        existingPayment.Currency = currency;
        existingPayment.CardNumber = cardNumber;
        existingPayment.CardCvv = cardCvv;

        await _paymentRepository.UpdatePaymentAsync(existingPayment);
        return existingPayment;
    }
}