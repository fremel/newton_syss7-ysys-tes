public class PaymentService : IPaymentService
{
    private readonly HttpClient _httpClient;

    public PaymentService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    public TransactionResult ProcessPayment(PaymentInfo paymentInfo)
    {
        var response = _httpClient.PostAsJsonAsync("http://localhost:8080/payment", paymentInfo).Result;
        response.EnsureSuccessStatusCode();
        return response.Content.ReadFromJsonAsync<TransactionResult>().Result;
    }

    public void ReportToAccounting(AccountingReport report)
    {
        var response = _httpClient.PostAsJsonAsync("http://localhost:8080/accounting", report).Result;
        response.EnsureSuccessStatusCode();
    }
}