using ECommerce.MVC.Areas.Admin.Models.ProductModels;
using ECommerce.MVC.Areas.Admin.Services.Abstract;
using ECommerce.MVC.Models.DiscountModels;
using ECommerce.MVC.Models.EnumResponseModels;
using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using System.Security.Claims;

namespace ECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly MVC.Services.Abstract.IEnumService enumService;
        private readonly MVC.Services.Abstract.ICategoryService categoryService;
        private readonly IDiscountService _discountService;
        private readonly IToastNotification _toaster;

        public ProductController(IProductService productService, MVC.Services.Abstract.IEnumService enumService, MVC.Services.Abstract.ICategoryService categoryService, IDiscountService discountService, IToastNotification toaster)
        {
            _productService = productService;
            this.enumService = enumService;
            this.categoryService = categoryService;
            _discountService = discountService;
            _toaster = toaster;
        }

        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetAllProductsAsync();
            return View(response.Data);
        }

        public async Task<IActionResult> GetProductsBySeller()
        {
            var sellerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = await _productService.GetProductBySellerAsync(sellerId);

            if (!response.IsSucceeded || response.Data == null)
            {
                ViewBag.ErrorMessage = "Henüz ürün bulunmamaktadır.";
                return View(new List<ProductModel>());
            }

          
            var colorsResponse = await enumService.GetAvailableColorsAsync();
            var sizesResponse = await enumService.GetAvailableSizesAsync();

            if (!colorsResponse.IsSucceeded || !sizesResponse.IsSucceeded)
            {
                ViewBag.ErrorMessage = "Beden veya renk bilgisi alınamadı.";
                return View(response.Data);
            }

            foreach (var product in response.Data)
            {
                product.Sizes = sizesResponse.Data
                    .Where(s => product.AvailableSizeIds.Contains(s.Id))
                    .Select(s => new EnumResponseModel { Id = s.Id, Name = s.Name })
                    .ToList();

                product.Colors = colorsResponse.Data
                    .Where(c => product.AvailableColorIds.Contains(c.Id))
                    .Select(c => new EnumResponseModel { Id = c.Id, Name = c.Name })
                    .ToList();
            }

            return View(response.Data);
        }



        public async Task<IActionResult> ProductDetail(int id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            var discountResponse = await _discountService.GetDiscountByProductIdAsync(id);
            var discountEntity = discountResponse.Data?.FirstOrDefault(); 

            if (!response.IsSucceeded) return NotFound();

            var categoryResponse = await categoryService.GetCategoryByIdAsync(response.Data.CategoryId);
            var colorsResponse = await enumService.GetAvailableColorsAsync();
            var sizesResponse = await enumService.GetAvailableSizesAsync();

            if (!colorsResponse.IsSucceeded || !sizesResponse.IsSucceeded || !categoryResponse.IsSucceeded)
            {
                ViewBag.ErrorMessage = "Kategori, renk veya beden bilgisi alınamadı.";
                return View(response.Data);
            }

            response.Data.Sizes = sizesResponse.Data
                .Where(s => response.Data.AvailableSizeIds.Contains(s.Id))
                .Select(s => new EnumResponseModel { Id = s.Id, Name = s.Name })
                .ToList();

            response.Data.Colors = colorsResponse.Data
                .Where(c => response.Data.AvailableColorIds.Contains(c.Id))
                .Select(c => new EnumResponseModel { Id = c.Id, Name = c.Name })
                .ToList();

            response.Data.CategoryName = categoryResponse.Data.Name;

            response.Data.Discounts = discountResponse.Data?.ToList() ?? new List<DiscountModel>();

            return View(response.Data);
        }



        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var model = new ProductCreateModel();  
            await LoadProductFormData();  
            return View(model); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(ProductCreateModel model)
        {
            
            if (model.Image != null)
            {
                Console.WriteLine("Resim mevcut.");
                model.ImageUrl = model.ImageUrl;
            }
            else if (string.IsNullOrEmpty(model.ImageUrl))
            {
                ModelState.AddModelError("", "Resim yüklenmesi zorunludur.");
                await LoadProductFormData();
                return View(model);
            }
  
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                TempData["ErrorMessage"] = string.Join("<br>", errors);
                await LoadProductFormData();
                return View(model);
            }

    
            model.AvailableSizes = model.AvailableSizeIds?.Select(id => new EnumResponseModel { Id = id }).ToList() ?? new List<EnumResponseModel>();
            model.AvailableColors = model.AvailableColorIds?.Select(id => new EnumResponseModel { Id = id }).ToList() ?? new List<EnumResponseModel>();
            model.IsActive = true;

     
            var response = await _productService.AddProductAsync(model);
            if (!response.IsSucceeded)
            {
                ModelState.AddModelError("", "Ürün eklenirken hata oluştu.");
                await LoadProductFormData();
                return View(model);
            }

            ViewBag.SuccessMessage = "Ürün başarıyla eklendi";


            return RedirectToAction("GetProductsBySeller");

        }
     



        private async Task LoadProductFormData()
        {
            ViewBag.Categories = new SelectList(
        (await categoryService.GetAllCategoriesAsync()).Data
        .Where(category => category.ParentCategoryId != null),
        "Id",
        "Name");



            ViewBag.Colors = new SelectList((await enumService.GetAvailableColorsAsync()).Data, "Id", "Name");
            ViewBag.Sizes = new SelectList((await enumService.GetAvailableSizesAsync()).Data, "Id", "Name");
        }

        [HttpPost]
        public async Task<IActionResult> SoftDeleteProduct(int id)
        {
            var response = await _productService.SoftDeleteProductAsync(id);
            if (!response.IsSucceeded)
            {
                return Json(new { success = false, message = "Ürün silinirken hata oluştu." });
            }
            return Json(new { success = true, message = "Ürün geçici olarak silindi." });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                var colorsResponse = await enumService.GetAvailableColorsAsync();
                var sizesResponse = await enumService.GetAvailableSizesAsync();
                var categoryResponse = await categoryService.GetAllCategoriesAsync();

                ViewBag.Categories = categoryResponse.Data.ToList();
                ViewBag.Colors = colorsResponse.Data.ToList();
                ViewBag.Sizes = sizesResponse.Data.ToList();
                TempData["ErrorMessage"] = "Ürün Güncellemede hata oluştu.";
                return View(model);
            }

            model.AvailableSizes = model.AvailableSizeIds
                .Select(id => new EnumResponseModel { Id = id })
                .ToList();

            model.AvailableColors = model.AvailableColorIds
                .Select(id => new EnumResponseModel { Id = id })
                .ToList();

            if (model.Image == null)
            {
                if (!string.IsNullOrEmpty(model.ImageUrl))
                {
                    model.ImageUrl = model.ImageUrl;
                }
                else
                {
                    model.ImageUrl = string.Empty;
                }
            }

            var response = await _productService.UpdateProductAsync(model);
            if (!response.IsSucceeded)
            {
                ModelState.AddModelError("", response.Errors[0].Message);

                var colorsResponse = await enumService.GetAvailableColorsAsync();
                var sizesResponse = await enumService.GetAvailableSizesAsync();
                var categoryResponse = await categoryService.GetAllCategoriesAsync();

                ViewBag.Categories = categoryResponse.Data.ToList();
                ViewBag.Colors = colorsResponse.Data.ToList();
                ViewBag.Sizes = sizesResponse.Data.ToList();

                return View(model);
            }

            TempData["SuccessMessage"] = "Ürün başarıyla güncellendi.";

     
            return RedirectToAction("Edit", new { id = model.Id });
        }


        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id); 
          


            var discountResponse = await _discountService.GetDiscountByProductIdAsync(id);
            var discount = discountResponse.Data?.FirstOrDefault();
            var colorsResponse = await enumService.GetAvailableColorsAsync();
            var sizesResponse = await enumService.GetAvailableSizesAsync();
            var categoryResponse = await categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categoryResponse.Data
                 .Where(c => c.ParentCategoryId != null)
                 .ToList();
           
            ViewBag.Colors = colorsResponse.Data.ToList();
            ViewBag.Sizes = sizesResponse.Data.ToList();


            var model = new ProductUpdateModel
            {
                Id = product.Data.Id,
                Name = product.Data.Name,
                Description = product.Data.Description,
                UnitPrice = product.Data.UnitPrice,
                Stock = product.Data.Stock,
                PreparationTimeInDays = product.Data.PreparationTimeInDays,
               CategoryId=product.Data.CategoryId,
               IsActive=product.Data.IsActive,
               ImageUrl=product.Data.ImageUrl,
                AvailableSizes = product.Data.Sizes,
                AvailableColors = product.Data.Colors,
                AvailableColorIds = product.Data.AvailableColorIds.ToList(),
                AvailableSizeIds = product.Data.AvailableSizeIds.ToList()

            };

            return View(model);
        }

    }
}
