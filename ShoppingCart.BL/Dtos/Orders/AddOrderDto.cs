using ShoppingCart.BL.Dtos.CartItems;
using ShoppingCart.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BL.Dtos.Orders;

public class AddOrderDto
{
  
    public IEnumerable<CartItemDto> OrderItems { get; set; } = [];
}
