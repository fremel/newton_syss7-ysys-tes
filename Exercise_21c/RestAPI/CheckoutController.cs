using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CheckoutController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public CheckoutController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public IActionResult Checkout([FromBody] PaymentInfo paymentInfo)
    {
        var transactionResult = _paymentService.ProcessPayment(paymentInfo);
        _paymentService.ReportToAccounting(new AccountingReport
        {
            PaymentAmount = transactionResult.AmountTransferred,
            TransactionFee = transactionResult.TransactionFee
        });

        return Ok(transactionResult);
    }
}