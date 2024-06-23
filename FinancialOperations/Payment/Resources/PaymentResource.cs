namespace FinancialOperations.Payment.Resources;

public record PaymentResource(float amount, string currency, string cardNumber, string cardCvv);