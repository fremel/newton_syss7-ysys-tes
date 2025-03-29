public interface IPaymentService
{
    TransactionResult ProcessPayment(PaymentInfo paymentInfo);
    void ReportToAccounting(AccountingReport report);
}