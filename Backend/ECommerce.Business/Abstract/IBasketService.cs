using ECommerce.Shared.DTOs.BasketDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IBasketService
    {
        Task<ResponseDTO<BasketCreateModel>> GetBasketAsync();
     
        Task<ResponseDTO<BasketCreateModel>> CreateBasketAsync(BasketCreateDTO basketCreateDTO);
        Task<ResponseDTO<NoContent>> ClearBasketAsync();
        Task<ResponseDTO<BasketItemDTO>> AddProductToBasketAsync(BasketItemCreateDTO basketItemCreateDTO);
        Task<ResponseDTO<NoContent>> RemoveProductFromBasketAsync(int basketItemId);
        Task<ResponseDTO<NoContent>> ChangeProductQuantityAsync(BasketItemChangeQuantityDTO basketItemChangeQuantityDTO);

       
        Task<ResponseDTO<decimal>> CalculateTotalAmountAsync();

    }
}
