public class OrderProcessor
{
    private const decimal TaxRate = 0.07m; // 7% tax
    private const decimal ShippingCostPerItem = 5.00m;

    public decimal CalculateTotalCost(int numberOfItems, decimal pricePerItem)
    {
        decimal baseCost = numberOfItems * pricePerItem;
        decimal taxAmount = baseCost * TaxRate;
        decimal shippingCost = numberOfItems * ShippingCostPerItem;
        decimal totalCost = baseCost + taxAmount + shippingCost;
        return totalCost;
    }
}
