using ECommerce.MVC.Models.EnumResponseModels;
using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Models.ReviewModels;
using ECommerce.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Linq;


namespace ECommerce.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IEnumService _enumService;
        private readonly IToastNotification _toaster;
        private readonly IUserAccountManagerService userAccountManagerService;
        private readonly IReviewService reviewService;

        public ProductController(IProductService productService, IToastNotification toaster, IEnumService enumService, IUserAccountManagerService userAccountManagerService, IReviewService reviewService)
        {
            _productService = productService;
            _toaster = toaster;
            _enumService = enumService;
            this.userAccountManagerService = userAccountManagerService;
            this.reviewService = reviewService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetAllProductAsync();

            if (!response.IsSucceeded || response.Data == null)
            {
                _toaster.AddErrorToastMessage("Ürünler getirilirken bir hata oluştu.");
                return View(new List<ProductModel>());
            }


            var colorsResponse = await _enumService.GetAvailableColorsAsync();
            var sizesResponse = await _enumService.GetAvailableSizesAsync();

            if (!colorsResponse.IsSucceeded || !sizesResponse.IsSucceeded)
            {
                _toaster.AddErrorToastMessage("Renkler veya bedenler alınırken bir hata oluştu.");
                return View(new List<ProductModel>());
            }


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

            var colorsResponse = await _enumService.GetAvailableColorsAsync();
            var sizesResponse = await _enumService.GetAvailableSizesAsync();
            var relatedProducts = await _productService.GetRelatedProductsAsync(id);

            if (!colorsResponse.IsSucceeded || !sizesResponse.IsSucceeded)
            {
                _toaster.AddErrorToastMessage("Beden veya renk bilgisi alınamadı.");
                return View(response.Data);
            }

            var product = response.Data;


            product.Sizes = sizesResponse.Data
                .Where(s => product.AvailableSizeIds.Contains(s.Id))
                .Select(s => new EnumResponseModel { Id = s.Id, Name = s.Name })
                .ToList();

            product.Colors = colorsResponse.Data
                .Where(c => product.AvailableColorIds.Contains(c.Id))
                .Select(c => new EnumResponseModel { Id = c.Id, Name = c.Name })
                .ToList();





            decimal discountAmount = 0;
            if (product.Discounts != null && product.Discounts.Any())
            {
                var maxDiscount = product.Discounts.Max(d => d.DiscountValue);
                discountAmount = (product.UnitPrice * maxDiscount) / 100;
            }
            ViewBag.DiscountedPrice = product.UnitPrice - discountAmount;
            if (!string.IsNullOrEmpty(product.ApplicationUserId))
            {
                var sellerResponse = await userAccountManagerService.GetSellerByIdAsync(product.ApplicationUserId);

                if (sellerResponse.IsSucceeded && sellerResponse.Data != null)
                {
                    ViewBag.StoreName = sellerResponse.Data.StoreName;
                    ViewBag.applicationUserId = product.ApplicationUserId;
                }
                else
                {
                    ViewBag.StoreName = "Bilinmeyen Satıcı";
                }
            }
            else
            {
                ViewBag.StoreName = "Bilinmeyen Satıcı";
            }

            var reviewResponse = await reviewService.GetReviewByProductIdAsync(id);

            if (reviewResponse == null || reviewResponse.Data == null)
            {
                ViewBag.Reviews = new List<ReviewModel>();
            }
            else if (reviewResponse.IsSucceeded)
            {
                ViewBag.Reviews = reviewResponse.Data;
            }
            else
            {
                ViewBag.Reviews = new List<ReviewModel>();
            }

            ViewBag.RelatedProducts = relatedProducts?.IsSucceeded == true ? relatedProducts.Data : new List<ProductModel>();

            return View(product);
        }

    }

}
