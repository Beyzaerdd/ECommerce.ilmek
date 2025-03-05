using ECommerce.MVC.Areas.Admin.Models.DiscountModels;
using ECommerce.MVC.Areas.Admin.Views.Shared.ResponseViewModels;
using ECommerce.MVC.Models.DiscountModels;
using ECommerce.Shared.DTOs.DiscountDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;

namespace ECommerce.MVC.Areas.Admin.Services.Abstract
{
    public interface IDiscountService
    {
        Task<ResponseViewModel<DiscountModel>> UpdateDiscountAsync(DiscountUpdateModel discountUptadeModel);
        Task<ResponseViewModel<bool>> DeleteDiscountAsync(int discountId);
        Task<ResponseViewModel<IEnumerable<DiscountModel>>> GetAllDiscountsAsync();

        Task<ResponseViewModel<DiscountModel>> CreateProductDiscountAsync(DiscountCreateModel discountCreateModel);
        Task<ResponseViewModel<DiscountModel>> CreateCouponCodeAsync(DiscountCreateModel discountCreateModel);
        Task<ResponseViewModel<IEnumerable<DiscountModel>>> GetDiscountByCouponCodeAsync(string couponCode);
        Task<ResponseViewModel<IEnumerable<DiscountModel>>> GetDiscountByProductIdAsync(int productId);

        Task<ResponseViewModel<IEnumerable<DiscountModel>>> GetDiscountBySellerAsync();
    }
}
