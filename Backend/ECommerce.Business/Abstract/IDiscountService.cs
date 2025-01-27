using ECommerce.Shared.DTOs.DiscountDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IDiscountService
    {
        
    
            Task<ResponseDTO<DiscountDTO>> UpdateDiscountAsync(DiscountUptadeDTO discountUpdateDTO);
            Task<ResponseDTO<bool>> DeleteDiscountAsync(int discountId);
            Task<ResponseDTO<IEnumerable<DiscountDTO>>> GetAllDiscountsAsync();
   
            Task<ResponseDTO<DiscountDTO>> CreateProductDiscountAsync(DiscountCreateDTO discountCreateDTO);
            Task<ResponseDTO<DiscountDTO>> CreateCouponCodeAsync(DiscountCreateDTO discountCreateDTO);
            Task<ResponseDTO<IEnumerable<DiscountDTO>>> GetDiscountByCouponCodeAsync(string couponCode);
             Task<ResponseDTO<IEnumerable<DiscountDTO>>> GetDiscountByProductIdAsync(int productId);  


    }
}
