using ECommerce.MVC.Models.CategoryModels;
using ECommerce.MVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.ViewComponents
{
    public class SubCategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

       
            public SubCategoriesViewComponent(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<IViewComponentResult> InvokeAsync(int parentCategoryId)
            {
                var response = await _categoryService.GetCategoriesByParentIdAsync(parentCategoryId);
                if (response.IsSucceeded && response.Data != null)
                {
                    return View(response.Data);
                }

                return View(new List<CategoryModel>());
            }
        }
        }

