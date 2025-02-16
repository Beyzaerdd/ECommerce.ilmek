using ECommerce.MVC.Models.ReviewModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.ReviewDTOs;

namespace ECommerce.MVC.Services.Abstract
{
    public interface IReviewService
    {
        Task<ResponseViewModel<NoContent>> AddReviewAsync(ReviewCreateModel reviewCreateModel);


        Task<ResponseViewModel<IEnumerable<ReviewModel>>> GetReviewByProductIdAsync(int productId);

        Task<ResponseViewModel<NoContent>> DeleteReviewAsync(int reviewId);

        Task<ResponseViewModel<NoContent>> UpdateReviewAsync(ReviewUpdateModel reviewUpdateModel);
    }
}
