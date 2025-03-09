using ECommerce.MVC.Areas.Admin.Services.Abstract;
using ECommerce.MVC.Models.ReviewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _reviewService.GetReviewBySellerProducts();

            if (!response.IsSucceeded || response.Data == null)
            {
                ViewBag.ErrorMessage = "Yorumlar getirilirken bir hata oluştu.";
                return View(new List<ReviewModel>());
            }

            return View(response.Data);
        }
    }
}
