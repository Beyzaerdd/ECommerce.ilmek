using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.ViewComponents
{
    public class LatestProductsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public LatestProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _productService.GetAllProductAsync(8);
            var products = response.IsSucceeded ? response.Data : new List<ProductModel>();

            return View(products);
        }
    }
}
