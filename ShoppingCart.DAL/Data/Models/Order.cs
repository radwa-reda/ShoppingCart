using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL.Data.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreationDateTime { get; set; }
    public decimal TotalPrice { get; set; }
    public ICollection<CartItem> OrderItems { get; set; } = [];
}
