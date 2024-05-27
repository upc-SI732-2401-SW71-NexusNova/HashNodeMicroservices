using FinancialOperations.Payment.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialOperations.Payment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PaymentService _paymentService;

    public PaymentController(PaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPayments()
    {
        var payments = await _paymentService.GetAllPaymentsAsync();
        return Ok(payments);
    }
    
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPayment(int id)
    {
        var payment = await _paymentService.GetPaymentAsync(id);
        if (payment == null)
        {
            return NotFound();
        }
        return Ok(payment);
    }


    [HttpPost]
    public async Task<IActionResult> CreatePayment(float amount, string currency, string cardNumber, string cardCvv)
    {
        var payment = await _paymentService.CreatePaymentAsync(amount, currency, cardNumber, cardCvv);
        return Ok(payment);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePayment(int id, float amount, string currency, string cardNumber, string cardCvv)
    {
        var updatedPayment = await _paymentService.UpdatePaymentAsync(id, amount, currency, cardNumber, cardCvv);
        if (updatedPayment == null)
        {
            return NotFound();
        }
        return Ok(updatedPayment);
    }
}