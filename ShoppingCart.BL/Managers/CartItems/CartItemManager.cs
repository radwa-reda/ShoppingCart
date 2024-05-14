using ShoppingCart.BL.Dtos.CartItems;
using ShoppingCart.DAL.Repositorries.UnitOfWork;
using ShoppingCart.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BL.Managers.CartItems;

public class CartItemManager : ICartItemManager
{
    private readonly IUnitOfWork _unitOfWork;

    public CartItemManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(AddCartItemsDot addCartItemsDot)
    {
        var cart = new CartItem
        {
            ProductId = addCartItemsDot.ProductId,
            Quantity = addCartItemsDot.Quantity
        };
        _unitOfWork.CartItemReopsitry.Add(cart);

        _unitOfWork.SaveChanges();
    }

    public void Delete(int id)
    {
        var cart= _unitOfWork.CartItemReopsitry.GetById(id);
        if(cart == null) { return; }
        _unitOfWork.CartItemReopsitry.Delete(cart);
        _unitOfWork.SaveChanges();
    }

    public void Edit(EditeCartItemsDot editeCartItemsDot)
    {
        var cartItem = _unitOfWork.CartItemReopsitry.GetById(editeCartItemsDot.Id);
        if(cartItem == null) { return;}
    
      
        cartItem.Quantity= editeCartItemsDot.Quantity;
        _unitOfWork.CartItemReopsitry.Update(cartItem);
        _unitOfWork.SaveChanges();
    }

    public IEnumerable<CartItemDetailsDOT> GetAll()
    {
        var cartItems = _unitOfWork.CartItemReopsitry.GetAll();
        return cartItems.Select(x => new CartItemDetailsDOT
        {
            Id = x.Id,
            Quantity = x.Quantity,
            ProductId = x.ProductId
        });
    }
}
