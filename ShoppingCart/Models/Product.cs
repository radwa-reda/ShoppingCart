namespace ShoppingCart.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public Product()
    {
    }

    public Product(int id, string name, 
        string category, decimal price, decimal quantity)
    {
        Id=id;
        Name=name;
        Category=category;
        Price=price;
        Quantity=quantity;
    }

    

}
