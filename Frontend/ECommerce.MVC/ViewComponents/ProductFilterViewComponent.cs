using ECommerce.MVC.Models.CategoryModels;
using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.MVC.ViewCompanents
{
    public class ProductFilterViewComponent : ViewComponent
    {
        private readonly IProductService product;

        public ProductFilterViewComponent(IProductService product)
        {
            this.product = product;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId, ProductFilterViewModel filterViewModel)
        {
            var response = await product.FilterProducts(
                categoryId,
                filterViewModel.SelectedSizes,
                filterViewModel.SelectedColors,
                filterViewModel.MinPrice,
                filterViewModel.MaxPrice);

            if (response.IsSucceeded)
            {
                return View(response.Data);
            }
            return View(new List<ProductModel>());
        }
    }
}





