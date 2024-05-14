using ShoppingCart.DAL.Repositorries.Products;
using ShoppingCart.DAL.Repositorries.Orders;
using ShoppingCart.DAL.Repositorries.CartItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace ShoppingCart.DAL.Repositorries.UnitOfWork;

public interface IUnitOfWork
{
    public IProductReopsitry ProductReopsitry { get; }
    public ICartItemReopsitry CartItemReopsitry { get; }

    public IOrderReopsitry OrderReopsitry { get; }

    void SaveChanges();
}
