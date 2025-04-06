namespace MyApp.Tests;

[TestClass]
public class OrderServiceTests
{
    private readonly OrderService _orderService = new OrderService();
    private List<Order> _orders;

    public OrderServiceTests()
    {
        // Set up a list of orders for benchmarking
        _orders = new List<Order>
            {
                new() { Price = 100 },
                new() { Price = 50 },
                new() { Price = 200 }
            };
    }

    [TestMethod]
    public void CalculateTotal_WithValidOrders_ShouldReturnCorrectTotal()
    {
        Assert.AreEqual(350d, _orderService.CalculateTotal(_orders), "Unexpected total!");
    }
}