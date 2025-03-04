using ECommerce.MVC.Areas.Admin.Models.ProductModels;
using ECommerce.MVC.Areas.Admin.Services.Abstract;
using ECommerce.MVC.Models.EnumResponseModels;
using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly MVC.Services.Abstract.IEnumService enumService;
        private readonly MVC.Services.Abstract.ICategoryService categoryService;

        public ProductController(IProductService productService, MVC.Services.Abstract.IEnumService enumService, MVC.Services.Abstract.ICategoryService categoryService)
        {
            _productService = productService;
            this.enumService = enumService;
            this.categoryService = categoryService;
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
            if (!response.IsSucceeded) return NotFound();
            return View(response.Data);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var response = await _productService.AddProductAsync(model);
            if (!response.IsSucceeded)
            {
                ModelState.AddModelError("", "Ürün eklenirken hata oluştu.");
                return View(model);
            }
            return RedirectToAction("GetAllProducts");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id, bool isHardDelete)
        {
            ResponseViewModel<NoContentViewModel> response;
            if (isHardDelete)
            {
                response = await _productService.HardDeleteProductAsync(id);
            }
            else
            {
                response = await _productService.SoftDeleteProductAsync(id);
            }

            if (!response.IsSucceeded)
            {
                TempData["Error"] = "Ürün silinirken hata oluştu.";
            }
            return RedirectToAction("GetAllProducts");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductUpdateModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _productService.UpdateProductAsync(model);
            if (!response.IsSucceeded)
            {
                ModelState.AddModelError("", response.Errors[0].Message);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
    
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id); // Assuming this method exists
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories =(await categoryService.GetAllCategoriesAsync()).Data.ToList();

            var model = new ProductUpdateModel
            {
                Id = product.Data.Id,
                Name = product.Data.Name,
                Description = product.Data.Description,
                UnitPrice = product.Data.UnitPrice,
                Stock = product.Data.Stock,
                PreparationTimeInDays = product.Data.PreparationTimeInDays,
               CategoryId=product.Data.CategoryId,
                AvailableSizes = product.Data.Sizes,
                AvailableColors = product.Data.Colors,
  
            };

            return View(model);
        }

    }
}
