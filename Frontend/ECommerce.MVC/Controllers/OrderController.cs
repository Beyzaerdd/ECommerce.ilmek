using ECommerce.MVC.Models.OrderModels;
using ECommerce.MVC.Models.ReviewModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.Shared.DTOs.OrderDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        private readonly IReviewService reviewService;

        public OrderController(IOrderService orderService, IBasketService basketService, IReviewService reviewService)
        {
            _orderService = orderService;
            _basketService = basketService;
            this.reviewService = reviewService;
        }


        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.Name; 
            var response = await _orderService.GetOrdersAsync(userId);
            if (!response.IsSucceeded)
            {
                TempData["Error"] = "Siparişler getirilirken bir hata oluştu.";
                return View(new List<OrderModel>());
            }
            return View(response.Data);
        }

        public async Task<IActionResult> Checkout()
        {
            var result = await _basketService.GetBasketAsync();
            if (!result.IsSucceeded)
            {
                TempData["ErrorMessage"] = "Sepet yüklenirken hata oluştu.";
                return RedirectToAction("Index", "Basket");
            }

            var totalAmountResult = await _basketService.CalculateTotalAmountAsync();
            if (!totalAmountResult.IsSucceeded)
            {
                TempData["ErrorMessage"] = totalAmountResult.Errors[0].Message;
                return RedirectToAction("Index", "Basket");
            }

            ViewBag.TotalAmount = totalAmountResult.Data;
            return View(new OrderCreateModel { BasketItems = result.Data.BasketItems });
        }
        [HttpPost]
        public async Task<IActionResult> CompleteOrder(OrderCreateModel orderCreateModel)
        {
            

            var basketResponse = await _basketService.GetBasketAsync();
            if (!basketResponse.IsSucceeded || basketResponse.Data == null || !basketResponse.Data.BasketItems.Any())
            {
                TempData["ErrorMessage"] = "Sepetiniz boş, sipariş oluşturulamadı.";
                return RedirectToAction("Index", "Basket");
            }

         
            var response = await _orderService.CreateOrderAsync();
            if (!response.IsSucceeded)
            {
                TempData["Error"] = "Sipariş oluşturulurken bir hata oluştu.";
                return RedirectToAction("Checkout");
            }

            

            

            TempData["Success"] = "Siparişiniz oluşturuldu! Faturanız e-posta ile iletilecektir.";
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> Orders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = await _orderService.GetOrdersAsync(userId);

            if (!response.IsSucceeded)
            {
                TempData["Error"] = "Siparişler getirilirken bir hata oluştu.";
                return View(new List<OrderModel>());
            }

            return View(response.Data);
        }

        public async Task<IActionResult> OrderDetails(string id)
        {
            var response = await _orderService.GetOrderAsync( id);

            if (!response.IsSucceeded || response.Data == null)
            {
                TempData["Error"] = "Sipariş detayları getirilirken bir hata oluştu.";
                return RedirectToAction("Orders");
            }

            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewCreateModel reviewCreateModel)
        {
            Console.WriteLine($"Controller'a Gelen OrderItemId: {reviewCreateModel.OrderItemId}");

            var response = await reviewService.AddReviewAsync(reviewCreateModel);

            if (!response.IsSucceeded)
            {
                TempData["Error"] = "Yorum eklenirken hata oluştu.";
            }


            return Json(new { success = true, message = "Yorum başarıyla eklendi!" });
        }
       


    }
}
