using ECommerce.MVC.Models.BasketModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.BasketDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;

namespace ECommerce.MVC.Services.Abstract
{
    public interface IBasketService
    {
        Task<ResponseViewModel<BasketModel>> GetBasketAsync();

        Task<ResponseViewModel<NoContentViewModel>> CreateBasketAsync(BasketModel basketModel);
        Task<ResponseViewModel<NoContentViewModel>> ClearBasketAsync();
        Task<ResponseViewModel<BasketItemModel>> AddProductToBasketAsync(AddBasketItemModel addBasketItemModel);
        Task<ResponseViewModel<NoContentViewModel>> RemoveProductFromBasketAsync(int basketItemId);
        Task<ResponseViewModel<NoContentViewModel>> ChangeProductQuantityAsync(BasketItemChangeQuantityModel basketItemChangeQuantityModel);


        Task<ResponseViewModel<decimal>> CalculateTotalAmountAsync();



    }
}
