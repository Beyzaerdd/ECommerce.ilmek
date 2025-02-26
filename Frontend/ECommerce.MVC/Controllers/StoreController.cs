using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Models.StoreModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Services.Concrete;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.MVC.Controllers
{
    [Route("store")]
    public class StoreController : Controller
    {
        private readonly IProductService _productService;

        private readonly IUserAccountManagerService _userAccountManagerService;
        private readonly IEnumService enumService;
        private readonly IConfiguration _configuration;

        public StoreController(IProductService productService, IUserAccountManagerService userAccountManagerService, IConfiguration configuration, IEnumService enumService)
        {
            _productService = productService;
            _userAccountManagerService = userAccountManagerService;

        }


        [HttpGet("{applicationUserId}")]
        public async Task<IActionResult> Index(string applicationUserId, int page = 1, int pageSize = 8)
        {
        
            var sellerResponse = await _userAccountManagerService.GetSellerByIdAsync(applicationUserId);

            if (!sellerResponse.IsSucceeded)
            {
              
                return View(new StoreViewModel
                {
                    StoreName = "Bilinmeyen Mağaza",
                    
                    ApplicationUserId = applicationUserId,
                    Products = new List<ProductModel>(),
                    PageNumber = page,
                    TotalPages = 1
                });
            }

     
            var response = await _productService.GetProductBySellerAsync(applicationUserId, pageSize);

            if (!response.IsSucceeded || response.Data == null || !response.Data.Any())
            {
                return View(new StoreViewModel
                {
                    StoreName = sellerResponse.Data?.StoreName ?? "Bilinmeyen Mağaza", 
                    ApplicationUserId = applicationUserId,
                    Products = new List<ProductModel>(),
                    PageNumber = page,
                    TotalPages = 1
                });
            }

            var totalProducts = response.Data.Count();
            var totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);

            var storeViewModel = new StoreViewModel
            {
                StoreName = sellerResponse.Data?.StoreName ?? "Bilinmeyen Mağaza", 
                ApplicationUserId = applicationUserId,
                Products = response.Data.ToList(),
                PageNumber = page,
                TotalPages = totalPages,
                Seller = sellerResponse.Data
            };

            return View(storeViewModel);
        }
    }
    }
