using ECommerce.MVC.Models.CategoryModels;
using ECommerce.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.ViewCompanents
{
    public class CategoriesOnMenuViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoriesOnMenuViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _categoryService.GetCategoriesByParent();
            if (response.IsSucceeded)
            {
                return View(response.Data); 
            }
            return View(new List<CategoryModel>());
        }
    }
}