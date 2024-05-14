using Microsoft.EntityFrameworkCore;
using ShoppingCart.DAL.Data.Context;
using ShoppingCart.DAL.Repositorries.CartItems;
using ShoppingCart.DAL.Repositorries.Orders;
using ShoppingCart.DAL.Repositorries.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL.Repositorries.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductContext _context;

    public IProductReopsitry ProductReopsitry { get; }
    public IOrderReopsitry OrderReopsitry { get; }

    public ICartItemReopsitry CartItemReopsitry { get; }

    public UnitOfWork( ProductContext context,IProductReopsitry productReopsitry,
        IOrderReopsitry orderReopsitry, ICartItemReopsitry cartItemReopsitry) {
        _context=context;
        ProductReopsitry = productReopsitry;
        OrderReopsitry = orderReopsitry;
        CartItemReopsitry = cartItemReopsitry;
    }
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
