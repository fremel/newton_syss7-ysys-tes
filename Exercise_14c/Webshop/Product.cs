public class Product
{
    public string name { get; set; }
    public float price { get; set; }
    public int quantity { get;set; }

    public Product(string name, float price, int quantity)
    {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
    }
}