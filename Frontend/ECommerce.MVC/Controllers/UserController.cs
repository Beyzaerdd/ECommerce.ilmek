using ECommerce.MVC.Models.UserModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.Shared.DTOs.UserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserAccountManagerService _userAccountManagerService;

        public UserController(IUserAccountManagerService userAccountManagerService)
        {
            _userAccountManagerService = userAccountManagerService;
        }


        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var response = await _userAccountManagerService.GetUserAccountDetails();

            if (!response.IsSucceeded || response.Data == null)
            {
                ViewData["ErrorMessage"] = "Profil bilgileri alınamadı.";
                return View("Error");
            }

         
            if (response.Data.Id == null)
            {
                ViewData["ErrorMessage"] = "Kullanıcı ID'si alınamadı.";
                return View("Error");
            }

            return View("UserProfile", response.Data);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateUserProfileModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View("UserProfile", model);
            }

            var result = await _userAccountManagerService.UpdateUserProfile(model);

            if (!result.IsSucceeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Message);
                }
                return View("UserProfile", model);
            }

            TempData["SuccessMessage"] = "Profiliniz başarıyla güncellendi!";
            return RedirectToAction("Profile");
        }



        [HttpGet]
        public async Task<IActionResult> SellerProfile()
        {
            var response = await _userAccountManagerService.GetSellerAccountDetails();

            if (!response.IsSucceeded || response.Data == null)
            {
                ViewData["ErrorMessage"] = "Satıcı profili alınamadı.";
                return View("Error");
            }

            return View("SellerProfile", response.Data);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSellerProfile(ApplicationUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("SellerProfile", model);
            }

            var result = await _userAccountManagerService.UpdateSellerProfile(model);

            if (!result.IsSucceeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Message);
                }
                return View("SellerProfile", model);
            }

            TempData["SuccessMessage"] = "Satıcı profiliniz başarıyla güncellendi!";
            return RedirectToAction("SellerProfile");
        }
    }
}

