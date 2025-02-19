using ECommerce.MVC.Models.ContactMessageModels;
using ECommerce.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactMessageService _contactMessageService;

        public ContactController(IContactMessageService contactMessageService)
        {
            _contactMessageService = contactMessageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ContactMessageCreateModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactMessageCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var response = await _contactMessageService.AddContactMessageAsync(model);

            if (response.IsSucceeded)
            {
                ViewBag.SuccessMessage = "Mesajınız başarıyla gönderildi!";
                return View("Index", new ContactMessageCreateModel());
            }

            ViewBag.ErrorMessage = "Mesaj gönderilirken bir hata oluştu. Lütfen tekrar deneyin.";
            return View("Index", model);
        }
    }
}