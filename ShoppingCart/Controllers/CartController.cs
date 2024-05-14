using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.BL.Dtos.CartItems;
using ShoppingCart.BL.Managers.CartItems;
using ShoppingCart.BL.Managers.Products;
using ShoppingCart.DAL.Data.Models;

namespace ShoppingCart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartItemManager _cartItemManager;

    public CartController(ICartItemManager cartItemManager )
    {
        _cartItemManager = cartItemManager;
    }
    [Authorize]
    [HttpGet]
    
    public ActionResult<IEnumerable<AddCartItemsDot>> GetAll()
    {
          var cartItems= _cartItemManager.GetAll();
          return Ok(cartItems);
    }
    [Authorize]
    [HttpPost]
    public ActionResult<AddCartItemsDot> AddToCart(AddCartItemsDot item)
    {
        _cartItemManager.Add(item);
        return Ok(new { Message = "Product Created Successfully" });

    }
    [Authorize]
    [HttpPut]
    [Route("{id}")]
    public ActionResult  EditCart(int id,EditeCartItemsDot editeCartItemsDot )
    {
         editeCartItemsDot.Id=id;
        _cartItemManager.Edit(editeCartItemsDot);
        return Ok(editeCartItemsDot);
       // return Ok(new { Message = "Product Updated Successfully" });

    }
    //  [Authorize(policy: "AdminOnly")]
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult RemoveFromCart(int id)
    {
        _cartItemManager.Delete(id);
        return Ok(new { Message = "Product Deleted Successfully" });

    }
}
