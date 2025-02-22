using ECommerce.MVC.Models.CategoryModels;

using ECommerce.MVC.Models.EnumResponseModels;
using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.ComplexTypes;

namespace ECommerce.MVC.Services.Abstract
{
    public interface IProductService
    {

        Task<ResponseViewModel<IEnumerable<ProductModel>>> GetAllProductAsync(int count = 9);
       

        Task<ResponseViewModel<ProductModel>> GetProductByIdAsync(int id);

        Task<ResponseViewModel<IEnumerable<ProductModel>>> GetProductsByCategory(int? categoryId);
        Task<ResponseViewModel<int>> getCountByCategory(int? categoryId);
        Task<ResponseViewModel<IEnumerable<ProductModel>>> GetCategoriesByParent();

        Task<ResponseViewModel<IEnumerable<ProductModel>>> GetRelatedProductsAsync(int productId);
        Task<ResponseViewModel<IEnumerable<ProductModel>>> FilterProducts(
        int categoryId,
        List<int>? selectedSizes,
        List<int>? selectedColors,
        decimal? minPrice,
        decimal? maxPrice);
       
    }
}
