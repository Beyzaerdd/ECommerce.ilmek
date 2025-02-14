using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;


    namespace ECommerce.MVC.Controllers
    {
        public class ProductController : Controller
        {
            private readonly IProductService _productService;
            private readonly IToastNotification _toaster;

            public ProductController(IProductService productService, IToastNotification toaster)
            {
                _productService = productService;
                _toaster = toaster;
            }

            public async Task<IActionResult> Index()
            {
            var response = await _productService.GetAllProductAsync();

            if (!response.IsSucceeded || response.Data == null)
            {
                _toaster.AddErrorToastMessage("Ürünler getirilirken bir hata oluştu.");
                return View(new List<ProductModel>());
            }

            // Renkler ve bedenler için veri al
            var colorsResponse = await _productService.GetAvailableColorsAsync();
            var sizesResponse = await _productService.GetAvailableSizesAsync();

            if (!colorsResponse.IsSucceeded || !sizesResponse.IsSucceeded)
            {
                _toaster.AddErrorToastMessage("Renkler veya bedenler alınırken bir hata oluştu.");
                return View(new List<ProductModel>());
            }

            // Renkler ve bedenler verisini View'a ilet
            ViewBag.Colors = colorsResponse.Data;
            ViewBag.Sizes = sizesResponse.Data;

            return View(response.Data);
        }

            public async Task<IActionResult> Details(int id)
            {
                var response = await _productService.GetProductByIdAsync(id);

                if (!response.IsSucceeded || response.Data == null)
                {
                    _toaster.AddErrorToastMessage("Ürün bilgisi alınamadı.");
                    return RedirectToAction("Index");
                }

                return View(response.Data);
            }

            public async Task<IActionResult> Category(int categoryId)
            {
                var response = await _productService.GetProductsByCategory(categoryId);

                if (!response.IsSucceeded || response.Data == null)
                {
                    _toaster.AddErrorToastMessage("Kategoriye ait ürünler bulunamadı.");
                    return RedirectToAction("Index");
                }

                return View(response.Data);
            }
        }
    }


