public class LoyaltyService
{
    private readonly IOrderRepository _orderRepository;
    private const decimal LoyaltyPointRate = 0.1m; // 10% of the total amount spent

    public LoyaltyService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public decimal CalculateLoyaltyPoints(string userId)
    {
        decimal totalAmountSpent = _orderRepository.GetTotalAmountSpent(userId);
        return totalAmountSpent * LoyaltyPointRate;
    }
}