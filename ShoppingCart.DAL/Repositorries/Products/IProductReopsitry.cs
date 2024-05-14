using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.DAL.Data.Models;
using ShoppingCart.DAL.Repositorries.Generic;
namespace ShoppingCart.DAL.Repositorries.Products;

public interface IProductReopsitry : IGenericReopsitry<Product>
{
    IEnumerable<Product> GetProducts(string cateogry, string name);
    decimal GetPriceById(int id);
}
