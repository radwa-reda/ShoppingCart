using ShoppingCart.BL.Dtos.CartItems;
using ShoppingCart.BL.Dtos.Orders;
using ShoppingCart.DAL.Data.Models;
using ShoppingCart.DAL.Repositorries.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BL.Managers.Orders;

public class OrderManager : IOrderManager
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void PlaceOrder(AddOrderDto addOrderDto)
    {
        decimal totalPrice = 0;
        foreach (var item in addOrderDto.OrderItems)
        {
            decimal productPrice = _unitOfWork.ProductReopsitry.GetPriceById(item.ProductId);
            totalPrice += productPrice * item.Quantity;
        }
        var order = new Order
        {
            CreationDateTime = DateTime.Now,
            TotalPrice = totalPrice,
            OrderItems =addOrderDto.OrderItems
            .Select(x => new CartItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList()
        };
        _unitOfWork.OrderReopsitry.Add(order);
        _unitOfWork.SaveChanges();

    }

    public IEnumerable<OrderDetailsDto> Viewordershistory()
    {
        var order = _unitOfWork.OrderReopsitry.GetAll();
        return order.Select(o => new OrderDetailsDto
        {
            Id=o.Id,
            CreationDateTime=DateTime.Now,
            TotalPrice = o.TotalPrice
        });
    }
}
