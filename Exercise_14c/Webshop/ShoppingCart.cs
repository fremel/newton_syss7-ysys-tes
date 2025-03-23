using System.Net.Http.Headers;

namespace Webshop;

public class ShoppingCart
{
    int _customerId;
    List<Product> _productsInCart;
    IPricingService _pricingService;
    ICustomerLoyaltyService _customerLoyaltyService;

    public ShoppingCart(int customerId, IPricingService pricingService, ICustomerLoyaltyService customerLoyaltyService)
    {
        _customerId = customerId;
        _productsInCart = new List<Product>();
        _pricingService = pricingService;
        _customerLoyaltyService = customerLoyaltyService;
    }

    public bool AddProduct(string name, int quantity)
    {
        return false;
    }

    public bool RemoveProduct(string name, int quantity)
    {
        return false;
    }

    public float CalculateTotalPrice()
    {
        return -1;
    }
}
