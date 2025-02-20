using ECommerce.MVC.Models.ReviewModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.ReviewDTOs;

namespace ECommerce.MVC.Services.Abstract
{
    public interface IReviewService
    {
        Task<ResponseViewModel<NoContentViewModel>> AddReviewAsync(ReviewCreateModel reviewCreateModel);


        Task<ResponseViewModel<IEnumerable<ReviewModel>>> GetReviewByProductIdAsync(int productId);

        Task<ResponseViewModel<NoContentViewModel>> DeleteReviewAsync(int reviewId);

        Task<ResponseViewModel<NoContentViewModel>> UpdateReviewAsync(ReviewUpdateModel reviewUpdateModel);
    }
}
