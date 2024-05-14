using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.BL.Dtos.Products;
using ShoppingCart.BL.Managers.Products;

namespace ShoppingCart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductManager _productManager;

    public ProductController(IProductManager productManager)
    {
        _productManager = productManager;
    }
    //[HttpGet]
    //public ActionResult<IEnumerable<ProductDetailsDto>> GetAll()
    //{
    //    var products = _productManager.GetAll();
    //    return products.ToList();
    //}
  //  [Authorize]
    [HttpGet("{id}")]
    public ActionResult<ProductDetailsDto> GetById(int id)
    {
        var product = _productManager.GetById(id);
        if (product == null)
        {
            return NotFound();
        }
        return product;

    }
   // [Authorize]
    [HttpGet]
    public ActionResult<ProductDetailsDto> GetProducts(string category=null!, string name=null! )
    {
        var productts = _productManager.GetProducts(category, name);
        return Ok(productts);
    }
}