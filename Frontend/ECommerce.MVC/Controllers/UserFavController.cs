using ECommerce.MVC.Models.UserFavModels;
using ECommerce.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.MVC.Controllers
{
    public class UserFavController : Controller
    {
        private readonly IUserFavService _userFavService;
        private readonly IUserAccountManagerService _userAccountManagerService;

        public UserFavController(IUserFavService userFavService, IUserAccountManagerService userAccountManagerService)
        {
            _userFavService = userFavService;
            _userAccountManagerService = userAccountManagerService;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            if (string.IsNullOrEmpty(userId))
            {
                TempData["Error"] = "Kullanıcı bilgisi alınamadı.";
                return View(new List<UserFavModel>());
            }

           
            var userByIdResponse = await _userAccountManagerService.GetUserByIdAsync(userId);

            if (userByIdResponse.IsSucceeded && userByIdResponse.Data != null)
            {
              
                ViewBag.UserName = userByIdResponse.Data.FirstName ?? "Bilinmeyen Kullanıcı";
            }
            else
            {
                TempData["Error"] = "Kullanıcı bilgileri alınamadı.";
                return View(new List<UserFavModel>());
            }

            // Favori ürünleri al
            var response = await _userFavService.GetUserFavoritesAsync();

            if (!response.IsSucceeded || response.Data == null)
            {
                TempData["Error"] = "Favori ürünler alınırken hata oluştu.";
                return View(new List<UserFavModel>());
            }

            var userFavorites = response.Data.Where(f => f.ApplicationUserId == userId).ToList();
            ViewBag.FavoriteCount = userFavorites.Count;

            var paginatedFavorites = userFavorites
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((double)userFavorites.Count / pageSize);

            return View(paginatedFavorites);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToFavorites(int productId)
        {
          
                var userResponse = await _userAccountManagerService.GetUserAccountDetails();

                if (!userResponse.IsSucceeded || userResponse.Data == null)
                {
                    TempData["Error"] = "Kullanıcı bilgisi alınamadı.";
                    return RedirectToAction("Index");
                }

                var model = new UserFavCreateModel { ProductId = productId };

                var response = await _userFavService.AddToFavoritesAsync(model);

                if (!response.IsSucceeded)
                {
                    TempData["Error"] = "Favorilere ekleme başarısız.";
                    return RedirectToAction("Index");
                }

                TempData["Success"] = "Ürün favorilere eklendi!";
            return RedirectToAction("Index");
        }

        [HttpPost]
  
        public async Task<IActionResult> RemoveFromFavorites(int favId)
        {
            var response = await _userFavService.RemoveFromFavoritesAsync(favId);

            if (!response.IsSucceeded)
            {
                TempData["Error"] = "Favori ürün silinirken hata oluştu.";
                return RedirectToAction("Index"); 
            }

            TempData["Success"] = "Ürün favorilerden silindi!";
            return RedirectToAction("Index");
        }


        [HttpGet("GetFavoriteCount")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> GetFavoriteCount()
        {
            var userResponse = await _userAccountManagerService.GetUserAccountDetails();

            if (!userResponse.IsSucceeded || userResponse.Data == null)
            {
                return Json(new { success = false, message = "Favori sayısı alınamadı." });
            }

            var response = await _userFavService.GetFavoriteCountAsync(userResponse.Data.Id);

            if (!response.IsSucceeded)
            {
                return Json(new { success = false, message = "Favori sayısı alınamadı." });
            }

            return Json(new { success = true, count = response.Data });
        }


    }
}
