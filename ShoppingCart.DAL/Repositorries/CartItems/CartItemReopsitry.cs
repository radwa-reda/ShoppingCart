using ShoppingCart.DAL.Data.Context;
using ShoppingCart.DAL.Repositorries.Generic;
using ShoppingCart.DAL.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.DAL.Repositorries.CartItems;

namespace ShoppingCart.DAL.Repositorries.CartItems;

public class CartItemReopsitry :GenericReopsitry<CartItem>,ICartItemReopsitry
{
    public CartItemReopsitry(ProductContext context)
         : base(context)
    {
    }
}
