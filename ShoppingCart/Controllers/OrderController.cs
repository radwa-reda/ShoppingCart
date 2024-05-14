using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.BL.Dtos.CartItems;
using ShoppingCart.BL.Dtos.Orders;
using ShoppingCart.BL.Managers.CartItems;
using ShoppingCart.BL.Managers.Orders;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager )
        {
            _orderManager = orderManager;
        }
        [Authorize]
        [HttpPost]
        public ActionResult<AddOrderDto> AddToCart(AddOrderDto item)
        {
            _orderManager.PlaceOrder(item);
            return Ok(new { Message = "Order Created Successfully" });

        }
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<OrderDetailsDto>> GetAll()
        {
            var orders = _orderManager.Viewordershistory();
            return Ok(orders);
        }
    }
}
