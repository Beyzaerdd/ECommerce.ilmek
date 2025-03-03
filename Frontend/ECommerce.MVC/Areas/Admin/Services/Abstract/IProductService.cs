using ECommerce.MVC.Areas.Admin.Models.ProductModels;
using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.ProductDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using System.Globalization;

namespace ECommerce.MVC.Areas.Admin.Services.Abstract
{
    public interface IProductService
    {
        Task<ResponseViewModel<IEnumerable<ProductModel>>> GetAllProductsAsync(int? take = null);
        Task<ResponseViewModel<ProductModel>> AddProductAsync(ProductCreateModel productCreateModel);

        Task<ResponseViewModel<NoContentViewModel>> UpdateProductAsync(ProductUpdateModel productUpdateModel);
        Task<ResponseViewModel<NoContentViewModel>> SoftDeleteProductAsync(int id);
        Task<ResponseViewModel<NoContentViewModel>> HardDeleteProductAsync(int id);

        Task<ResponseViewModel<ProductModel>> GetProductByIdAsync(int id);
        Task<ResponseViewModel<int>> GetProductCountAsync(bool? isActive);
        Task<ResponseViewModel<IEnumerable<ProductModel>>> GetProductBySellerAsync(string applicationUserId, int? take = null);

    }
}
