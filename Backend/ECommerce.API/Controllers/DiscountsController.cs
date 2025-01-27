using ECommerce.Business.Abstract;
using ECommerce.Shared.DTOs;
using ECommerce.Business.Concrete;
using ECommerce.Shared.DTOs.DiscountDTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.API.Controllers
{
    [Authorize(Policy = "SellerAndAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : CustomControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProductDiscount([FromBody] DiscountCreateDTO discountCreateDTO)
        {
            var response = await _discountService.CreateProductDiscountAsync(discountCreateDTO);
            return CreateResponse(response);
        }
   
        [HttpPost("createCoupon")]
        public async Task<IActionResult> CreateCouponCode([FromBody] DiscountCreateDTO discountCreateDTO)
        {
            var response = await _discountService.CreateCouponCodeAsync(discountCreateDTO);
            return CreateResponse(response);
        }
      
        [HttpPut]
        public async Task<IActionResult> UpdateDiscount([FromBody] DiscountUptadeDTO discountUpdateDTO)
        {
            var response = await _discountService.UpdateDiscountAsync(discountUpdateDTO);
            return CreateResponse(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount([FromRoute] int id)
        {
            var response = await _discountService.DeleteDiscountAsync(id);
            return CreateResponse(response);
        }
        [HttpGet("getallDiscounts")]
        public async Task<IActionResult> GetAllDiscounts([FromQuery] bool? isActive = null)
        {
            var response = await _discountService.GetAllDiscountsAsync();
            return CreateResponse(response);
        }
        [HttpGet("getby/{id}")]
        public async Task<IActionResult> GetDiscountById([FromRoute] int id)
        {
            var response = await _discountService.GetDiscountByProductIdAsync(id);
            return CreateResponse(response);
        }
        

    }
}
