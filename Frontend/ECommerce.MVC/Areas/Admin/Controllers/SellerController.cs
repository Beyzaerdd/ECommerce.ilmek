using ECommerce.MVC.Areas.Admin.Models.AccountModels;
using ECommerce.MVC.Models.UserModels;
using ECommerce.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SellerController : Controller
    {

        private readonly IUserAccountManagerService userAccountManagerService;

        public SellerController(IUserAccountManagerService userAccountManagerService)
        {
            this.userAccountManagerService = userAccountManagerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AccountDetails()
        {
            var response = await userAccountManagerService.GetSellerAccountDetails();
            if (response.IsSucceeded)
            {
                return View(response.Data);
            }
            else
            {
                // Handle errors if needed
                TempData["Error"] = "Hesap bilgileri alınırken bir hata oluştu.";
                return View();
            }
        }

        // Update seller profile
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(SellerAccountUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await userAccountManagerService.UpdateSellerProfile(model);
                if (response.IsSucceeded)
                {
                    TempData["Success"] = "Profil başarıyla güncellendi.";
                    return RedirectToAction("AccountDetails");
                }
                else
                {
                    // Display error
                    TempData["Error"] = "Profil güncellenirken bir hata oluştu.";
                }
            }
            return View("AccountDetails", model); // Return to AccountDetails view with current model
        }
    }
}
    

