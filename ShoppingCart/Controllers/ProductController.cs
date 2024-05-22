using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.BL.Dtos.Products;
using ShoppingCart.BL.Managers.Products;
using ShoppingCart.DAL.Data.Models;

namespace ShoppingCart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductManager _productManager;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IProductManager productManager, ILogger<ProductController> logger)
    {
        _productManager = productManager;
        _logger = logger;
    }
    [HttpGet("getAllProduct")]
   
    public ActionResult<IEnumerable<ProductDetailsDto>> GetAll()
    {
        var products = _productManager.GetAll();
        return Ok(products);
    }
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
   
    [HttpPost]
    public ActionResult<AddProductDto> Add(AddProductDto addProductDto)
    {

        var url = imageToURL(addProductDto.URL);
        _productManager.Add(addProductDto, url);

        return Ok(new { Message = "Product Created Successfully" });
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id) {

        _productManager.Delete(id);
        return Ok(new { Message = "Product Deleted Successfully" });
    }

    [HttpPut("{id:int}")]
    public ActionResult Update( int id, [FromForm] UpdateProductDto updateProductDto)
    {
        updateProductDto.Id= id;
        
        var url = imageToURL(updateProductDto.URL);
        _productManager.Edit(updateProductDto,url);
        return Ok(new { Message = "Product updated Successfully" });
    }

    private string imageToURL(IFormFile file)
    {
        //cheake on Extension
        var extention = Path.GetExtension(file.FileName);
        //Store image

        var newFileName = $"{Guid.NewGuid()}{extention}";
        var directory = Path.Combine(Environment.CurrentDirectory, "Images"); // Combine directory path
        var fullPath = Path.Combine(directory, newFileName); // Combine full file path


        using var stream = new FileStream(fullPath, FileMode.Create);
        file.CopyTo(stream);

        //Generate URL
        var url = $"{Request.Scheme}://{Request.Host}/Images/{newFileName}";
        return url;
    }
}