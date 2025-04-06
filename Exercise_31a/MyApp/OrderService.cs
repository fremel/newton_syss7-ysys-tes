namespace MyApp;

public class OrderService
{
    public double CalculateTotal(List<Order> orders)
    {
        // Simulating some calculation
        return orders.Sum(order => order.Price);
    }

    public bool IsOrderValid(Order order)
    {
        // Simulate validation logic
        return order != null && order.Price > 0;
    }
}

