using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BL.Dtos.Orders;

public class OrderDetailsDto
{
    public int Id { get; set; }
    public DateTime CreationDateTime { get; set; }
    public decimal TotalPrice { get; set; }
}
