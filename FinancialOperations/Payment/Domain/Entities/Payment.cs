namespace FinancialOperations.Payment.Domain.Entities;

public class Payment
{
    public int Id { get; set; }
    public float Amount { get; set; }
    public string Currency { get; set; }
    public string CardNumber { get; set; }
    public string CardCvv { get; set; }
}