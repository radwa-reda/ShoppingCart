using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.DAL.Data.Context;
using ShoppingCart.DAL.Data.Models;
using ShoppingCart.DAL.Repositorries.Generic;
namespace ShoppingCart.DAL.Repositorries.Products;

public class ProductReopsitry : GenericReopsitry<Product>, IProductReopsitry
{
    protected readonly ProductContext _context;
    public ProductReopsitry(ProductContext context)
         : base(context)
    {
        _context=context;
    }

    public IEnumerable<Product> GetProducts(string cateogry, string name)
    {
            var query = _context.products.AsQueryable();
            if (!string.IsNullOrEmpty(cateogry))
            {
                query = query.Where(p => p.Category == cateogry);
            }
            else
            {
                return query;
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }
            else
            {
                return query;
            }
            return query.ToList();
        
    }
    public decimal GetPriceById(int id)
    {
        var productprice = _context.products.FirstOrDefault(p => p.Id == id);
        if (productprice == null)
        {
            return 0;
        }
        return productprice.Price;
    }
}
