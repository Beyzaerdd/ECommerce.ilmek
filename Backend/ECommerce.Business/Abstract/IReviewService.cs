using ECommerce.Shared.DTOs.ContactMessageDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.ReviewDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IReviewService
    {
        Task<ResponseDTO<NoContent>> AddReviewAsync(ReviewCreateDTO reviewCreateDTO);

       
        Task<ResponseDTO<IEnumerable<ReviewDTO>>> GetReviewByProductIdAsync(int productId);


        Task<ResponseDTO<NoContent>> DeleteReviewAsync(int reviewId);

        Task<ResponseDTO<NoContent>> UpdateReviewAsync(ReviewUptadeDTO reviewUptadeDTO);
    }
}
