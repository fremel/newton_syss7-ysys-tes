public class OrderService
{
    private readonly IEmailService _emailService;

    public OrderService(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public void PlaceOrder(OrderDetails orderDetails)
    {
        // ... logic to process the order ...

        // Send an order confirmation email
        var emailContent = $"Thank you for your order! Order ID: {orderDetails.OrderId}";
        _emailService.SendEmail(orderDetails.CustomerEmail, "Order Confirmation", emailContent);
    }
}