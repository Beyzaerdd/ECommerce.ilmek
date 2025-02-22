using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs.BasketDTOs;
using ECommerce.Shared.DTOs.EnumDTOs;
using ECommerce.Shared.DTOs.ProductDTOs;
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

        public async Task<ResponseDTO<BasketDTO>> GetBasketAsync()
        {
            var userId = contextAccessor.GetUserId();
            var basket = await _unitOfWork.GetRepository<Basket>().GetAsync(
                x => x.ApplicationUserId == userId,
                query => query
                    .Include(b => b.BasketItems)
                    .ThenInclude(bi => bi.Product)
                    .ThenInclude(p => p.Discounts)
            );

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


            var basketDTO = new BasketDTO
            {
                BasketItems = basket.BasketItems.Select(item =>
                {
                    var product = item.Product;
                    decimal originalPrice = product.UnitPrice;
                    decimal discountedPrice = originalPrice;



                    if (product.Discounts != null)
                    {
                        var activeDiscount = product.Discounts
                            .Where(d => d.Type == DiscountType.Product
                                        && d.IsActive
                                        && d.StartDate <= DateTime.Now
                                        && d.EndDate >= DateTime.Now)
                            .MaxBy(d => d.DiscountValue);


                        if (activeDiscount != null)
                        {
                            decimal discountAmount = (originalPrice * activeDiscount.DiscountValue) / 100m;
                            discountedPrice = originalPrice - discountAmount;
                        }
                    }

                    return new BasketItemDTO
                    {
                        Id = item.Id,
                        BasketId = item.BasketId,
                        ProductId = product.Id,
                        Quantity = item.Quantity,
                        OriginalPrice = originalPrice,
                        DiscountedPrice = discountedPrice,
                        Size = new EnumDTO { Id = (int)item.Size, Name = item.Size.GetDisplayName()},
                        Color = new EnumDTO { Id = (int)item.Color, Name = item.Color.GetDisplayName() },
                        Product = new ProductDTO
                        {
                            Id = product.Id,
                            Name = product.Name,
                         ImageUrl = product.ImageUrl,
                            UnitPrice = product.UnitPrice,
                            ApplicationUserId = product.ApplicationUserId,
                            IsActive = product.IsActive,

                        }
                    };
                }).ToList()
            };


            return ResponseDTO<BasketDTO>.Success(basketDTO, HttpStatusCode.OK);
        }




        public async Task<ResponseDTO<BasketCreateDTO>> CreateBasketAsync(BasketCreateDTO basketCreateDTO)
        {
            var user = await _unitOfWork.GetRepository<ApplicationUser>()
                .GetAsync(u => u.Id == basketCreateDTO.ApplicationUserId);

            if (user == null)
            {
                return ResponseDTO<BasketCreateDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail { Message = "User not found.", Code = "USER_NOT_FOUND", Target = "ApplicationUser" }
        }, HttpStatusCode.NotFound);
            }

            var basket = _mapper.Map<Basket>(basketCreateDTO);
            basket.ApplicationUserId = basketCreateDTO.ApplicationUserId;

            await _unitOfWork.GetRepository<Basket>().AddAsync(basket);
            await _unitOfWork.SaveChangesAsync();

            var basketDTO = _mapper.Map<BasketCreateDTO>(basket);

            return ResponseDTO<BasketCreateDTO>.Success(basketDTO, HttpStatusCode.Created);
        }



        public async Task<ResponseDTO<NoContent>> ClearBasketAsync()
        {
            var userId = contextAccessor.GetUserId();
            var basket = await _unitOfWork.GetRepository<Basket>()
                .GetAsync(x => x.ApplicationUserId == userId,
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
            var userId = contextAccessor.GetUserId();
            var basket = await _unitOfWork.GetRepository<Basket>().GetAsync(x => x.ApplicationUserId == userId, query => query.Include(b => b.BasketItems).ThenInclude(bi => bi.Product));
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

            if (!product.IsActive)
            {
                return ResponseDTO<BasketItemDTO>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Product is not active.",
                        Code = "PRODUCT_ISNT_ACTIVE",
                        Target = "ProductIsActive"
                    }
                }, HttpStatusCode.NotFound);

            }
            if (!product.AvailableSizes.Contains(basketItemCreateDTO.Size))
            {
                return ResponseDTO<BasketItemDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Selected size is not available for this product.",
                Code = "SIZE_NOT_AVAILABLE",
                Target = "Size"
            }
        }, HttpStatusCode.BadRequest);
            }

            if (!product.AvailableColors.Contains(basketItemCreateDTO.Color))
            {
                return ResponseDTO<BasketItemDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Selected color is not available for this product.",
                Code = "COLOR_NOT_AVAILABLE",
                Target = "Color"
            }
        }, HttpStatusCode.BadRequest);
            }


            var existingBasketItem = basket.BasketItems.FirstOrDefault(x =>
         x.ProductId == basketItemCreateDTO.ProductId &&
         x.Size == basketItemCreateDTO.Size &&
         x.Color == basketItemCreateDTO.Color);

            if (existingBasketItem != null)
            {
         
                existingBasketItem.Quantity += basketItemCreateDTO.Quantity;
                 _unitOfWork.GetRepository<BasketItem>().UpdateAsync(existingBasketItem);
            }
            else
            {
    
                var basketItem = _mapper.Map<BasketItem>(basketItemCreateDTO);
                basketItem.BasketId = basket.Id;
                await _unitOfWork.GetRepository<BasketItem>().AddAsync(basketItem);
            }

            await _unitOfWork.SaveChangesAsync();

            var basketItemDTO = _mapper.Map<BasketItemDTO>(existingBasketItem ?? _mapper.Map<BasketItem>(basketItemCreateDTO));
            return ResponseDTO<BasketItemDTO>.Success(basketItemDTO, HttpStatusCode.OK);
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



        public async Task<ResponseDTO<decimal>> CalculateTotalAmountAsync()
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