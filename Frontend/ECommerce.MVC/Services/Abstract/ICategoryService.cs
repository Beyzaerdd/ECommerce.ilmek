using ECommerce.MVC.Models.CategoryModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;

namespace ECommerce.MVC.Services.Abstract
{
    public interface ICategoryService
    {
        Task<ResponseViewModel<IEnumerable<CategoryModel>>> GetAllCategoriesAsync();
        Task<ResponseViewModel<IEnumerable<CategoryModel>>> GetActiveCategoriesAsync();

        Task<ResponseViewModel<CategoryModel>> GetCategoryByIdAsync(int id);

        Task<ResponseViewModel<List<CategoryModel>>> GetCategoriesByParentIdAsync(int? parentId);
        Task<ResponseViewModel<int>> GetCategoryCountAsync();
        Task<ResponseViewModel<IEnumerable<CategoryModel>>> GetCategoriesByParent();

    }
}
