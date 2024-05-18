using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL.Data.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public string URL { get; set; } = string.Empty;

    public Product()
    {
    }

    public Product(int id, string name,
        string category, decimal price, int quantity,string url)
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        Quantity = quantity;
        URL = url;
    }

}
