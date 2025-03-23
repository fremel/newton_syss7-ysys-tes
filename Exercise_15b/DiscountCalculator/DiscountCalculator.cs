namespace DiscountCalculator;

public class DiscountCalculator
{
    public double CalculateDiscount(double orderAmount, bool isPremiumMember)
    {
        double discount = 0.0;
        if (orderAmount > 100)
        {
            discount = 10; // 10% discount for orders over $100
            if (isPremiumMember)
            {
                discount += 5; // Additional 5% discount for premium members
            }
        }
        else if (isPremiumMember)
        {
            discount = 5; // 5% discount for premium members on orders $100 or below
        }
        return discount;
    }
}
