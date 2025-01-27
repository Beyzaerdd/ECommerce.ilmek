using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs.BasketDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class BasketService : IBasketService


    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor contextAccessor;

        public BasketService(IMapper mapper, IDiscountService discountService, IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            this.discountService = discountService;
            _unitOfWork = unitOfWork;
            this.contextAccessor = contextAccessor;
        }

        private readonly IDiscountService discountService;

        public async Task<ResponseDTO<BasketDTO>> GetBasketAsync(string applicationUserId)
        {
            var basket = await _unitOfWork.GetRepository<Basket>().GetAsync(x => x.ApplicationUserId == applicationUserId);
            if (basket == null)
            {
                return ResponseDTO<BasketDTO>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Basket not found.",
                        Code = "BASKET_NOT_FOUND",
                        Target = "Basket"
                    }
                }, HttpStatusCode.NotFound);
            }
                 var basketDTO = _mapper.Map<BasketDTO>(basket);
                return ResponseDTO<BasketDTO>.Success(basketDTO, HttpStatusCode.OK);
            }

     

        public async Task<ResponseDTO<BasketDTO>> CreateBasketAsync(BasketCreateDTO basketCreateDTO)
        {
            var basket = _mapper.Map<Basket>(basketCreateDTO);
           await _unitOfWork.GetRepository<Basket>().AddAsync(basket);
           await _unitOfWork.SaveChangesAsync();
            var basketDTO = _mapper.Map<BasketDTO>(basket);
            return ResponseDTO<BasketDTO>.Success(basketDTO, HttpStatusCode.Created);

        }

        public async Task<ResponseDTO<NoContent>> ClearBasketAsync(string applicationUserId)
        {
           
            var basket = await _unitOfWork.GetRepository<Basket>()
                .GetAsync(x => x.ApplicationUserId == applicationUserId,
                          query => query.Include(b => b.BasketItems).ThenInclude(bi => bi.Product));

            if (basket == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Basket not found.",
                Code = "BASKET_NOT_FOUND",
                Target = "Basket"
            }
        }, HttpStatusCode.NotFound);
            }

           basket.BasketItems.Clear();

            _unitOfWork.GetRepository<Basket>().UpdateAsync(basket);

            await _unitOfWork.SaveChangesAsync();

         
            return ResponseDTO<NoContent>.Success(HttpStatusCode.OK);
        }


        public async Task<ResponseDTO<BasketItemDTO>> AddProductToBasketAsync(BasketItemCreateDTO basketItemCreateDTO)
        {
            var basket = await _unitOfWork.GetRepository<Basket>().GetAsync(x => x.Id == basketItemCreateDTO.BasketId, query => query.Include(b => b.BasketItems).ThenInclude(bi => bi.Product));
            if (basket == null)
            {
                return ResponseDTO<BasketItemDTO>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Basket not found.",
                        Code = "BASKET_NOT_FOUND",
                        Target = "Basket"
                    }
                }, HttpStatusCode.NotFound);
            }

            var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(basketItemCreateDTO.ProductId);
            if (product == null)
            {
                return ResponseDTO<BasketItemDTO>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Product not found.",
                        Code = "PRODUCT_NOT_FOUND",
                        Target = "ProductId"
                    }
                }, HttpStatusCode.NotFound);
            }

            var existingBasketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == basketItemCreateDTO.ProductId);
            if (existingBasketItem != null)
            {
                existingBasketItem.Quantity += basketItemCreateDTO.Quantity;
                _unitOfWork.GetRepository<BasketItem>().UpdateAsync(existingBasketItem);
                var basketItemDTO = _mapper.Map<BasketItemDTO>(existingBasketItem);
                return ResponseDTO<BasketItemDTO>.Success(basketItemDTO, HttpStatusCode.OK);
            }
            else
            {
                var basketItem = _mapper.Map<BasketItem>(basketItemCreateDTO);
               basket.BasketItems.Add(basketItem);
                _unitOfWork.GetRepository<Basket>().UpdateAsync(basket);
                await _unitOfWork.SaveChangesAsync();
                var basketItemDTO = _mapper.Map<BasketItemDTO>(basketItem);
                return ResponseDTO<BasketItemDTO>.Success(basketItemDTO, HttpStatusCode.Created);

            }



        }
        public async Task<ResponseDTO<NoContent>> RemoveProductFromBasketAsync(int basketItemId)
        {
            var basketItem = await _unitOfWork.GetRepository<BasketItem>().GetByIdAsync(basketItemId);
            if (basketItem == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Basket item not found.",
                        Code = "BASKET_ITEM_NOT_FOUND",
                        Target = "BasketItemId"
                    }
                }, HttpStatusCode.NotFound);
            }

           basketItem.IsDeleted = true;
            await _unitOfWork.GetRepository<BasketItem>().HardDeleteAsync(x => x.Id == basketItem.Id);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<NoContent>> ChangeProductQuantityAsync(BasketItemChangeQuantityDTO basketItemChangeQuantityDTO)
        {
           var basketItem = await _unitOfWork.GetRepository<BasketItem>().GetByIdAsync(basketItemChangeQuantityDTO.BasketItemId);
            if (basketItem == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Basket item not found.",
                        Code = "BASKET_ITEM_NOT_FOUND",
                        Target = "BasketItemId"
                    }
                }, HttpStatusCode.NotFound);
            }

            basketItem.Quantity = basketItemChangeQuantityDTO.Quantity;
            _unitOfWork.GetRepository<BasketItem>().UpdateAsync(basketItem);
            await _unitOfWork.SaveChangesAsync();
            return ResponseDTO<NoContent>.Success(HttpStatusCode.OK);
        }

    

        public async Task<ResponseDTO<decimal>> CalculateTotalAmountAsync(string couponCode)
        {

            var userId = contextAccessor.GetUserId();
            var basket = await _unitOfWork.GetRepository<Basket>().GetAsync(x => x.ApplicationUserId == userId, query => query.Include(b => b.BasketItems).ThenInclude(bi => bi.Product));
            if (basket == null || !basket.BasketItems.Any())
            {
                return ResponseDTO<decimal>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Basket is empty or invalid.",
                Code = "BASKET_EMPTY",
                Target = "Basket"
            }
        }, HttpStatusCode.BadRequest);
            }

            decimal totalAmount = 0;

            foreach (var item in basket.BasketItems)
            {
                var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(item.ProductId);
                if (product == null)
                {
                    return ResponseDTO<decimal>.Fail(new List<ErrorDetail>
            {
                new ErrorDetail
                {
                    Message = $"Product with ID {item.ProductId} not found.",
                    Code = "PRODUCT_NOT_FOUND",
                    Target = "BasketItems.ProductId"
                }
            }, HttpStatusCode.NotFound);
                }

                totalAmount += product.UnitPrice * item.Quantity;
            }

            
            if (!string.IsNullOrEmpty(couponCode))
            {
                var coupon = await _unitOfWork.GetRepository<Discount>().GetAsync(x => x.CouponCode == couponCode && x.IsActive
                                                                                    && x.StartDate <= DateTime.Now && x.EndDate >= DateTime.Now);
                if (coupon != null)
                {
                    if (coupon.Type == DiscountType.Coupon)
                    {
                        totalAmount -= (totalAmount * coupon.DiscountValue) / 100m;
                    }
                }
                else
                {
                    return ResponseDTO<decimal>.Fail(new List<ErrorDetail>
            {
                new ErrorDetail
                {
                    Message = "Invalid or expired coupon code.",
                    Code = "INVALID_COUPON",
                    Target = "CouponCode"
                }
            }, HttpStatusCode.BadRequest);
                }
            }

        
            var productIds = basket.BasketItems.Select(x => x.ProductId).ToList();
            var discounts = await _unitOfWork.GetRepository<Discount>().GetAllAsync(x => x.Type == DiscountType.Product
                      && x.ProductId.HasValue 
                      && productIds.Contains(x.ProductId.Value) 
                      && x.IsActive
                      && x.StartDate <= DateTime.Now
                      && x.EndDate >= DateTime.Now);

            foreach (var discount in discounts)
            {
                var basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == discount.ProductId);
                if (basketItem != null)
                {
                    var product = await _unitOfWork.GetRepository<Product>().GetByIdAsync(basketItem.ProductId);
                    if (product != null)
                    {
                        totalAmount -= (product.UnitPrice * basketItem.Quantity * discount.DiscountValue) / 100m;
                    }
                }
            }

            return ResponseDTO<decimal>.Success(totalAmount, HttpStatusCode.OK);
        }

    }
}
