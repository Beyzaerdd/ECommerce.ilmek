using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.Shared.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace ECommerce.MVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<ShopController> _logger;
        private readonly IConfiguration _configuration;

      

        public ShopController(IProductService productService, ICategoryService categoryService, ILogger<ShopController> logger, IConfiguration configuration)
        {
            _productService = productService;
            _categoryService = categoryService;
            _logger = logger;
            _configuration = configuration;
        }

   

        [HttpGet]
        public async Task<IActionResult> Index(int? categoryId, List<int>? selectedSizes, List<int>? selectedColors, List<string>? selectedPriceRanges, int page = 1, int pageSize = 9)
        {

            ViewBag.ApiBaseUrl = _configuration["ApiSettings:BaseUrl"];
            _logger.LogInformation($"CategoryId: {categoryId}");
            _logger.LogInformation($"SelectedSizes: {string.Join(",", selectedSizes ?? new List<int>())}");
            _logger.LogInformation($"SelectedColors: {string.Join(",", selectedColors ?? new List<int>())}");
            _logger.LogInformation($"SelectedPriceRanges: {string.Join(",", selectedPriceRanges ?? new List<string>())}");

            if (categoryId == null)
            {
                return View(new ProductFilterViewModel());
            }

            var categoryResponse = await _categoryService.GetCategoryByIdAsync(categoryId.Value);
            if (categoryResponse.IsSucceeded && categoryResponse.Data != null)
            {
                ViewBag.SelectedCategoryId = categoryId;
                ViewBag.SelectedCategoryName = categoryResponse.Data.Name;
            }
            else
            {
                ViewBag.SelectedCategoryName = "Kategori Bulunamadı";
            }

            var colorsResponse = await _productService.GetAvailableColorsAsync();
            var sizesResponse = await _productService.GetAvailableSizesAsync();
            decimal? minPrice = null;
            decimal? maxPrice = null;

            if (selectedPriceRanges != null && selectedPriceRanges.Any())
            {
                var priceValues = selectedPriceRanges
                    .Select(range =>
                    {
                        var parts = range.Split('-');
                        return new
                        {
                            Min = decimal.Parse(parts[0].Trim()),
                            Max = decimal.Parse(parts[1].Trim())
                        };
                    })
                    .ToList();

                minPrice = priceValues.Min(p => p.Min);
                maxPrice = priceValues.Max(p => p.Max);
            }
            var productResponse = await _productService.FilterProducts(categoryId.Value, selectedSizes, selectedColors, minPrice, maxPrice);

            var allProducts = productResponse.IsSucceeded && productResponse.Data != null
                ? productResponse.Data.ToList()
                : new List<ProductModel>();

            // 📌 Sayfalama için ürünleri bölüyoruz
            var paginatedProducts = allProducts.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var viewModel = new ProductFilterViewModel
            {
                CategoryId = categoryId,
                CategoryName = categoryResponse.Data.Name,
                SelectedSizes = selectedSizes ?? new List<int>(),
                SelectedColors = selectedColors ?? new List<int>(),
                SelectedPriceRanges = selectedPriceRanges ?? new List<string>(),
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                AvailableSizes = sizesResponse.IsSucceeded && sizesResponse.Data != null
                    ? sizesResponse.Data.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList()
                    : new List<SelectListItem>(),
                AvailableColors = colorsResponse.IsSucceeded && colorsResponse.Data != null
                    ? colorsResponse.Data.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList()
                    : new List<SelectListItem>(),

                // 📌 Sayfalama için güncellenmiş ürün listesi
                Products = paginatedProducts,
                TotalCount = allProducts.Count,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)allProducts.Count / pageSize)
            };

            return View(viewModel);
        }
      



    }
}

