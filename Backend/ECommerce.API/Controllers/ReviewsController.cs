using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.ReviewDTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerce.API.Controllers
{
    [Authorize(Policy = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : CustomControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

    
        [HttpPost("addReview")]
        public async Task<IActionResult> AddReview([FromBody] ReviewCreateDTO reviewCreateDTO)
        {
            var response = await reviewService.AddReviewAsync(reviewCreateDTO);
            return Ok(response);
        }

      
        [HttpDelete("deleteReview/{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var response = await reviewService.DeleteReviewAsync(reviewId);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }
            return NoContent();
        }

     
        [HttpGet("getReviewsByProductId")]
        public async Task<IActionResult> GetReviewByProductId([FromQuery] int productId)
        {
            var response = await reviewService.GetReviewByProductIdAsync(productId);
            return Ok(response);
        }

    
        [HttpPut("updateReview")]
        public async Task<IActionResult> UpdateReview([FromBody] ReviewUptadeDTO reviewUptadeDTO)
        {
            var response = await reviewService.UpdateReviewAsync(reviewUptadeDTO);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }
            return NoContent();
        }
    }
}
