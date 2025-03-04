using ECommerce.MVC.Areas.Admin.Services.Abstract;
using ECommerce.MVC.Areas.Admin.Views.Shared.ResponseViewModels;
using ECommerce.MVC.Models.OrderModels;
using ECommerce.Shared.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStatus(int orderId, OrderStatus status)
        {
          
            var response = await _orderService.UpdateOrderStatusAsync(orderId, status);

            if (!response.IsSucceeded)
            {
            
                ViewBag.ErrorMessage = response.Errors[0].Message;
                return View("Index"); 
            }

          
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> GetOrdersBySeller()
        {
            var sellerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = await _orderService.GetOrdersBySellerIdAsync(sellerId);

            if (!response.IsSucceeded)
            {
                ViewBag.ErrorMessage = response.Errors[0].Message;
                return View("Index");
            }


            var orders = response.Data;
            return View(orders);
        }
    
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var response = await _orderService.DeleteOrderAsync(id);

            if (!response.IsSucceeded)
            {
                ViewBag.ErrorMessage = response.Errors[0].Message;
                return View("Index"); 
            }

          
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            var response = await _orderService.GetOrderAsync(id);

            if (!response.IsSucceeded || response.Data == null)
            {
                TempData["Error"] = "Sipariş detayları getirilirken bir hata oluştu.";
                return RedirectToAction("Orders");
            }

            return View(response.Data);
        }
    }
}
