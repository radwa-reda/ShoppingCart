using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.DAL.Data.Context;
using ShoppingCart.DAL.Repositorries.CartItems;
using ShoppingCart.DAL.Repositorries.Orders;
using ShoppingCart.DAL.Repositorries.Products;
using ShoppingCart.DAL.Repositorries.UnitOfWork;


namespace ShoppingCart.DAL;

public static class ServicesExtensions
{
    public static void AddDALServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("EcommeraceDb");
        services.AddDbContext<ProductContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IProductReopsitry, ProductReopsitry>();
        services.AddScoped<IOrderReopsitry, OrderReopsitry>();
       services.AddScoped<ICartItemReopsitry, CartItemReopsitry>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

    }
}
