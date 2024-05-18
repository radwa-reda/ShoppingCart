using Microsoft.AspNetCore.Http;
using ShoppingCart.BL.Dtos.CartItems;
using ShoppingCart.BL.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BL.Managers.Products;

public interface IProductManager
{
    IEnumerable<ProductDetailsDto> GetAll();
    ProductDetailsDto? GetById(int id);

    IEnumerable<ProductDetailsDto> GetProducts(string cateogry, string name);

    void Add(AddProductDto addProductDto ,string url);
    void Delete(int id);

    void Edit(UpdateProductDto updateProductDto, string url);
    void Edit1(UpdateProductDto updateProductDto);
}
