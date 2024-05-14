using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.BL.Managers.CartItems;
using ShoppingCart.BL.Managers.Orders;
using ShoppingCart.BL.Managers.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BL;

public static class ServicesExtensions
{
    public static void AddBLServices(this IServiceCollection services)
    {
        services.AddScoped<IProductManager, ProductManager>();
        services.AddScoped<ICartItemManager, CartItemManager>();
        services.AddScoped<IOrderManager, OrderManager>();
    }
}
