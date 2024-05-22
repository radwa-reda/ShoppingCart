using Azure.Core;
using Microsoft.AspNetCore.Http;
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

    

    public void Add(AddProductDto addProductDto, string url)
    {
        var newproduct = new Product
        {
            Name = addProductDto.Name,
            Category = addProductDto.Category,
            Price = addProductDto.Price,
            Quantity = addProductDto.Quantity,
            URL = url
        };
        _unitOfWork.ProductReopsitry.Add(newproduct);
        _unitOfWork.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = _unitOfWork.ProductReopsitry.GetById(id);
        if (product == null) { return; }
        _unitOfWork.ProductReopsitry.Delete(product);
        _unitOfWork.SaveChanges();
    }

    public void Edit(UpdateProductDto updateProductDto, string url)
    {
        var product = _unitOfWork.ProductReopsitry.GetById(updateProductDto.Id);
        if (product == null) { return; }
        product.Price= updateProductDto.Price;
        product.Quantity= updateProductDto.Quantity;
        product.URL = url;
        _unitOfWork.ProductReopsitry.Update(product);
        _unitOfWork.SaveChanges();
    }

    public void Edit1(UpdateProductDto updateProductDto)
    {
        var product = _unitOfWork.ProductReopsitry.GetById(updateProductDto.Id);
        if (product == null) { return; }
        //product.Name= updateProductDto.Name;
        //product.Category= updateProductDto.Category;
        product.Price = updateProductDto.Price;
        product.Quantity = updateProductDto.Quantity;
        //product.URL = url;
        _unitOfWork.ProductReopsitry.Update(product);
        _unitOfWork.SaveChanges();
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
            URL = p.URL
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
            URL = product.URL
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
