﻿using ECommerce.Business.Abstract;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.DTOs.BasketDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs; 

using Microsoft.AspNetCore.Authorization;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : CustomControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateBasket([FromBody] BasketCreateDTO basketCreateDTO)
        {
            var response = await _basketService.CreateBasketAsync(basketCreateDTO);
            return CreateResponse(response);
        }



        [Authorize(Policy = "User")]
        [HttpGet("getBasket")]
        public async Task<IActionResult> GetBasket()
        {
            var response = await _basketService.GetBasketAsync();
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpDelete("clearBasket")]
        public async Task<IActionResult> ClearBasket()
        {
            var response = await _basketService.ClearBasketAsync();
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpPost("addProductToBasket")]
        public async Task<IActionResult> AddProductToBasket([FromBody] BasketItemCreateDTO basketItemCreateDTO)
        {
            var response = await _basketService.AddProductToBasketAsync(basketItemCreateDTO);
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpDelete("removeProductFromBasket/{basketItemId}")]
        public async Task<IActionResult> RemoveProductFromBasket([FromRoute] int basketItemId)
        {
            var response = await _basketService.RemoveProductFromBasketAsync(basketItemId);
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpPut("changeProductQuantity")]
        public async Task<IActionResult> ChangeProductQuantity([FromBody] BasketItemChangeQuantityDTO basketItemChangeQuantityDTO)
        {
            var response = await _basketService.ChangeProductQuantityAsync(basketItemChangeQuantityDTO);
            return CreateResponse(response);
        }
        [Authorize]
        [HttpGet("calculateTotalAmount")]
        public async Task<IActionResult> CalculateTotalAmount()
        {
            var response = await _basketService.CalculateTotalAmountAsync();
            return CreateResponse(response);
        }

        
   


    }
}
