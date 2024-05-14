using ShoppingCart.BL.Dtos.Orders;
using ShoppingCart.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BL.Managers.Orders;

public interface IOrderManager
{
    void PlaceOrder(AddOrderDto addOrderDto);
    IEnumerable<OrderDetailsDto> Viewordershistory();
}
