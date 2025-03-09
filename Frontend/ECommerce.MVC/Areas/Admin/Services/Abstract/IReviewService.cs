using ECommerce.MVC.Areas.Admin.Views.Shared.ResponseViewModels;
using ECommerce.MVC.Models.ReviewModels;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.ReviewDTOs;

namespace ECommerce.MVC.Areas.Admin.Services.Abstract
{
    public interface IReviewService
    {
        Task<ResponseViewModel<IEnumerable<ReviewModel>>> GetReviewBySellerProducts();
    }
}
