using ECommerce.MVC.Models.BasketModels;
using ECommerce.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;

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
     
            var result = await _basketService.GetBasketAsync();

            if (!result.IsSucceeded)
            {
            
                TempData["ErrorMessage"] = result.Errors[0].Message;
                return RedirectToAction("Index", "Home");
               
            }

     
            var basketModel = result.Data;

    
            var totalAmountResult = await _basketService.CalculateTotalAmountAsync();

            if (!totalAmountResult.IsSucceeded)
            {
                TempData["ErrorMessage"] = totalAmountResult.Errors[0].Message;
            }
            else
            {
         
                ViewBag.TotalAmount = totalAmountResult.Data;
            }

            return View(basketModel);
        }



        [HttpPost]
        public async Task<IActionResult> AddProductToBasket(AddBasketItemModel addBasketItemModel)
        {
            var result = await _basketService.AddProductToBasketAsync(addBasketItemModel);
            if (!result.IsSucceeded)
            {
          
                TempData["ErrorMessage"] = result.Errors[0].Message;
                return RedirectToAction("Index");
            }

       
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> ChangeProductQuantity(BasketItemChangeQuantityModel basketItemChangeQuantityModel)
        {
            var result = await _basketService.ChangeProductQuantityAsync(basketItemChangeQuantityModel);
            if (!result.IsSucceeded)
            {
        
                TempData["ErrorMessage"] = result.Errors[0].Message;
                return RedirectToAction("Index");
            }

    
            return RedirectToAction("Index");
        }

  
        [HttpPost]
        public async Task<IActionResult> RemoveProductFromBasket(int basketItemId)
        {
            var result = await _basketService.RemoveProductFromBasketAsync(basketItemId);
            if (!result.IsSucceeded)
            {
           
                TempData["ErrorMessage"] = result.Errors[0].Message;
                return RedirectToAction("Index");
            }

      
            return RedirectToAction("Index");
        }

    
        [HttpPost]
        public async Task<IActionResult> ClearBasket()
        {
            var result = await _basketService.ClearBasketAsync();
            if (!result.IsSucceeded)
            {
          
                TempData["ErrorMessage"] = result.Errors[0].Message;
                return RedirectToAction("Index");
            }

       
            return RedirectToAction("Index");
        }

 
        public async Task<IActionResult> CalculateTotalAmount()
        {
            var response = await _basketService.CalculateTotalAmountAsync();

            if (!response.IsSucceeded)
            {
                // Hata durumu, hatayı kullanıcıya iletmek
                ViewBag.Error = response.Errors.FirstOrDefault()?.Message;
                return View("Error");
            }

            // Hesaplanan toplam tutarı View'a göndermek
            ViewBag.TotalAmount = response.Data;

            return View();

        }
    } 




}