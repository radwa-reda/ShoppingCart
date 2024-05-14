using Microsoft.EntityFrameworkCore;
using ShoppingCart.DAL.Data.Context;
using ShoppingCart.DAL.Data.Models;
using ShoppingCart.DAL.Repositorries.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL.Repositorries.Orders;

public class OrderReopsitry : GenericReopsitry<Order>, IOrderReopsitry
{
    protected readonly ProductContext _context;
    public OrderReopsitry(ProductContext context)
         : base(context)
    {
        _context = context;
    }

   
}
