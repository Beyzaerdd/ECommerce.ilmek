using ECommerce.MVC.Models.BasketModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.BasketDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;

namespace ECommerce.MVC.Services.Abstract
{
    public interface IBasketService
    {
        Task<ResponseViewModel<BasketModel>> GetBasketAsync();

        Task<ResponseViewModel<bool>> CreateBasketAsync(BasketModel basketModel);
        Task<ResponseViewModel<NoContentViewModel>> ClearBasketAsync();
        Task<ResponseViewModel<BasketItemModel>> AddProductToBasketAsync(BasketItemModel basketItemModel);
        Task<ResponseViewModel<NoContentViewModel>> RemoveProductFromBasketAsync(int basketItemId);
        Task<ResponseViewModel<NoContentViewModel>> ChangeProductQuantityAsync(BasketItemChangeQuantityModel basketItemChangeQuantityModel);


        Task<ResponseViewModel<decimal>> CalculateTotalAmountAsync();

    }
}
