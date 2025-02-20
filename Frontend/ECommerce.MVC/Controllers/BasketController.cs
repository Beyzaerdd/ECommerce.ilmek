using ECommerce.MVC.Models.BasketModels;
using ECommerce.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _basketService.GetBasketAsync();
            if (!response.IsSucceeded)
            {
                ModelState.AddModelError("", "Sepet yüklenirken bir hata oluştu.");
                return View(new BasketModel());
            }
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(BasketItemModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var response = await _basketService.AddProductToBasketAsync(model);
            if (!response.IsSucceeded)
            {
                ModelState.AddModelError("", "Ürün sepete eklenirken bir hata oluştu.");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(BasketItemChangeQuantityModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            await _basketService.ChangeProductQuantityAsync(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProduct(int basketItemId)
        {
            await _basketService.RemoveProductFromBasketAsync(basketItemId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ClearBasket()
        {
            await _basketService.ClearBasketAsync();
            return RedirectToAction("Index");
        }
    }
}