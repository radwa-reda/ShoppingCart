using Microsoft.EntityFrameworkCore;
using ShoppingCart.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace ShoppingCart.DAL.Data.Context;

public class ProductContext:IdentityDbContext<User>
{
    public DbSet<Product> products => Set<Product>();
    public DbSet<Order> orders => Set<Order>();
    public DbSet<CartItem> cartItems => Set<CartItem>();
    public ProductContext(DbContextOptions options):base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var products = new List<Product>
                {

                  new Product {
                    Id= 1,
                    Name= "product1",
                    Category= "computers",
                    Price= 2000,
                    Quantity= 10,
                  },
                  new Product {
                    Id= 2,
                    Name= "product2",
                    Category= "TV",
                    Price= 4000,
                    Quantity= 20,
                  },
                  new Product {
                    Id= 3,
                    Name= "product3",
                    Category= "Watches",
                    Price= 2000,
                    Quantity= 10,
                  },
                  new Product {
                    Id= 4,
                    Name= "product4",
                    Category= "Smart Watches",
                    Price= 2890,
                    Quantity= 50,
                  },
                  new Product {
                    Id= 5,
                    Name= "product5",
                    Category= "Laptops",
                    Price= 2900,
                    Quantity= 90,
                  }
        };
        var orders = new List<Order>
                {

                  new Order {
                    Id= 1,
                    CreationDateTime= DateTime.Now,
                    TotalPrice=1000
                  },
                   new Order {
                    Id= 2,
                    CreationDateTime= DateTime.Now,
                    TotalPrice=2000
                  },
                    new Order {
                    Id= 3,
                    CreationDateTime= DateTime.Now,
                    TotalPrice=3000
                  },
                     new Order {
                    Id= 4,
                    CreationDateTime= DateTime.Now,
                    TotalPrice=4000
                  },
                      new Order {
                    Id= 5,
                    CreationDateTime= DateTime.Now,
                    TotalPrice=5000
                  }

        };

        var cartitems = new List<CartItem>
                {

                  new CartItem {
                      Id= 1,
                    ProductId= 1,
                    Quantity=2
                  },
                  new CartItem {
                        Id= 2,
                    ProductId= 2,
                    Quantity=3
                  },
                  new CartItem {
                        Id= 3,
                    ProductId= 2,
                    Quantity=4
                  },
                  new CartItem {
                      Id = 4,
                    ProductId= 4,
                    Quantity=1
                  },
                  new CartItem {
                      Id = 5,
                    ProductId= 3,
                    Quantity=4
                  },

        };

        modelBuilder.Entity<Product>().HasData(products);
        modelBuilder.Entity<Order>().HasData(orders);
        modelBuilder.Entity<CartItem>().HasData(cartitems);

    }
}
