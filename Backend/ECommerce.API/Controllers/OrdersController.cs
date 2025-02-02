using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete;
using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs.OrderDTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [Authorize(Policy = "User")]
        [HttpPost("createOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDTO orderCreateDTO)
        {
            var response = await orderService.CreateOrderAsync(orderCreateDTO);
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpGet("getOrderBy/{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var response = await orderService.GetOrderAsync(id);
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetOrders()
        {
            var response = await orderService.GetOrdersAsync();
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpGet("status/{orderStatus}")]
        public async Task<IActionResult> GetOrdersByStatus([FromQuery] OrderStatus orderStatus)
        {
            var response = await orderService.GetOrdersAsync(orderStatus);
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpGet("user/{applicationUserId}")]
        public async Task<IActionResult> GetUserOrders(string applicationUserId)
        {
            var response = await orderService.GetOrdersAsync(applicationUserId);
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpGet("date-range")]
        public async Task<IActionResult> GetOrdersByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var response = await orderService.GetOrdersAsync(startDate, endDate);
            return CreateResponse(response);
        }
        [Authorize(Policy = "SellerAndAdmin")]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderUpdateDTO orderUpdateDTO)
        {
            var response = await orderService.UpdateOrderAsync(orderUpdateDTO);
            return CreateResponse(response);
        }
        [Authorize(Policy = "SellerAndAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var response = await orderService.DeleteOrderAsync(id);
            return CreateResponse(response);
        }
        [Authorize(Policy = "SellerAndAdmin")]
        [HttpGet("getOrdersBySeller/{sellerId}")]
        public async Task<IActionResult> GetOrdersBySeller(string sellerId)
        {
            var response = await orderService.GetOrdersBySellerIdAsync(sellerId);
            return CreateResponse(response);

        }

    }

}
