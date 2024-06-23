namespace FinancialOperations.Payment.Resources;

public record PaymentPutResource(int id, float amount, string currency, string cardNumber, string cardCvv);