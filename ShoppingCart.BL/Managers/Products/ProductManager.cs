using ShoppingCart.BL.Dtos.Products;
using ShoppingCart.DAL.Data.Models;
using ShoppingCart.DAL.Repositorries.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BL.Managers.Products;

public class ProductManager : IProductManager
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork=unitOfWork;
    }
    public IEnumerable<ProductDetailsDto> GetAll()
    {
        var products= _unitOfWork.ProductReopsitry.GetAll();
        return products.Select(p => new ProductDetailsDto
        {
          Id = p.Id,
          Name = p.Name,
          Category = p.Category,
          Price = p.Price,
          Quantity = p.Quantity,
        });
    }

    public ProductDetailsDto? GetById(int id)
    {
        var product = _unitOfWork.ProductReopsitry.GetById(id);
        if(product == null)
        {
            return null;
        }
        return  new ProductDetailsDto
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category,
            Price = product.Price,
            Quantity = product.Quantity,
        };
    }

    public IEnumerable<ProductDetailsDto> GetProducts(string cateogry, string name)
    {
        var products = _unitOfWork.ProductReopsitry.GetProducts(cateogry ?? "", name ?? "");
        
        return products.Select(p => new ProductDetailsDto
        {
            Id = p.Id,
            Name = p.Name,
            Category = p.Category,
            Price = p.Price,
            Quantity = p.Quantity,
        });
      
    }
}
