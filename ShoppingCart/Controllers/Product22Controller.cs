using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Product22Controller : ControllerBase
{
    private static List<Product> _products = 
[
    new(1,"product1","computers",2000,10),
    new(2,"product2","TV",4000,20),
    new(3,"product3","Watches",2900,16),
    new(4,"product4","Smart Watches",9000,34),
    new(5,"product5","Laptops",40000,44),

];
    [HttpGet]
    public ActionResult GetAll()
    {
        if (!_products.Any())
        {
            return NoContent();
        }
        return Ok( _products );
    }
    [HttpGet]
    [Route("{id}")]
    public ActionResult GetById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null)
        {
            return NotFound();  
        }
        return Ok(product);
    }
    [HttpPost]
    public ActionResult<Product> Create(Product newProduct)
    {
        newProduct.Id=_products.Max(p => p.Id)+1;
        _products.Add(newProduct);

        return CreatedAtAction(nameof(GetById), new {id=newProduct.Id},
            new {Message="Product Created Successfully"});
    }
    [HttpPut("{id}")]
    public ActionResult Update(int id, Product updateProduct)
    {
        if (id != updateProduct.Id)
        {
            return BadRequest();
        }
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null)
        {
            return NotFound();
        }
        product.Quantity = updateProduct.Quantity;
        product.Name = updateProduct.Name;
        return Ok(updateProduct);
    }
    [HttpDelete("{id}")]
    
    public ActionResult Delete(int id)
    {
      
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null)
        {
            return NotFound();
        }
       _products.Remove(product);
        return Ok(new { Message = "Product Deleted Successfully" });
    }
}
