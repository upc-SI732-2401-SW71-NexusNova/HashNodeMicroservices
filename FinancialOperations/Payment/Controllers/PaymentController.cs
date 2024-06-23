using FinancialOperations.Payment.Application.Services;
using FinancialOperations.Payment.Resources;
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
    public async Task<IActionResult> CreatePayment([FromBody] PaymentResource resource)
    {
        var payment = await _paymentService.CreatePaymentAsync(resource.amount, resource.currency, resource.cardNumber, resource.cardCvv);
        return Ok(payment);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePayment([FromBody] PaymentPutResource resource)
    {
        var updatedPayment = await _paymentService.UpdatePaymentAsync(resource.id, resource.amount, resource.currency, resource.cardNumber, resource.cardCvv);
        if (updatedPayment == null)
        {
            return NotFound();
        }
        return Ok(updatedPayment);
    }
}