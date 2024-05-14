using ShoppingCart.BL.Dtos.CartItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BL.Managers.CartItems;

public interface ICartItemManager
{
    void Add(AddCartItemsDot addCartItemsDot);
    IEnumerable<CartItemDetailsDOT> GetAll();
    void Edit(EditeCartItemsDot editeCartItemsDot);
    void Delete(int id);
}
