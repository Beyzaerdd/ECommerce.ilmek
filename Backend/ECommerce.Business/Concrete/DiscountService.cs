﻿using AutoMapper;
using AutoMapper.Internal;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.CategoryDTOs;
using ECommerce.Shared.DTOs.DiscountDTOs;
using Microsoft.AspNetCore.Http;
using ECommerce.Shared.DTOs.ResponseDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using ECommerce.Shared.Extensions;

namespace ECommerce.Business.Concrete
{
    public class DiscountService : IDiscountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IProductService productService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public DiscountService(IProductService productService, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.productService = productService;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseDTO<DiscountDTO>> CreateCouponCodeAsync(DiscountCreateDTO discountCreateDTO)
        {
          
            var userRoles = httpContextAccessor.GetUserRoles();
            var existingCouponCode = await unitOfWork.GetRepository<Discount>().GetAsync(x => x.CouponCode == discountCreateDTO.CouponCode);

            if (existingCouponCode != null)
            {

                return ResponseDTO<DiscountDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Coupon code already exists.",
                Code = "COUPON_CODE_EXISTS",
                Target = "CouponCode"
            }
        }, HttpStatusCode.BadRequest);
            }
            if (!userRoles.Contains("Admin"))
            {
                return ResponseDTO<DiscountDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "You can only apply discounts to your own products.",
                Code = "UNAUTHORIZED",
                Target = nameof(discountCreateDTO.ProductId)
            }
        }, HttpStatusCode.Forbidden);
            }

            var discount = mapper.Map<Discount>(discountCreateDTO);
            discount.Type = discountCreateDTO.Type;

            discount.IsActive = true;
            discount.ApplicationUserId = httpContextAccessor.GetUserId();
            await unitOfWork.GetRepository<Discount>().AddAsync(discount);
            await unitOfWork.SaveChangesAsync();
            var discountDTO = mapper.Map<DiscountDTO>(discount);
            return ResponseDTO<DiscountDTO>.Success(discountDTO, HttpStatusCode.Created);


        }

        public async Task<ResponseDTO<DiscountDTO>> CreateProductDiscountAsync(DiscountCreateDTO discountCreateDTO)
        {
            var userId = httpContextAccessor.GetUserId();
            var userRoles = httpContextAccessor.GetUserRoles();

            var product = await unitOfWork.GetRepository<Product>().GetByIdAsync(discountCreateDTO.ProductId.Value);
            if (product == null)
            {
                return ResponseDTO<DiscountDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = $"Product not found with {discountCreateDTO}",
                Code = "PRODUCT_NOT_FOUND",
                Target = nameof(discountCreateDTO.ProductId)
            }
        }, HttpStatusCode.NotFound);
            }
            if (!userRoles.Contains("Admin") && product.ApplicationUserId != userId)
            {
                return ResponseDTO<DiscountDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "You can only apply discounts to your own products.",
                Code = "UNAUTHORIZED",
                Target = nameof(discountCreateDTO.ProductId)
            }
        }, HttpStatusCode.Forbidden);
            }

            var discount = mapper.Map<Discount>(discountCreateDTO);
            discount.Type = Shared.ComplexTypes.DiscountType.Product;
            discount.IsActive = true;
            discount.StartDate = DateTime.Now;
            discount.EndDate = discountCreateDTO.EndDate;
            discount.ProductId = discountCreateDTO.ProductId;
            discount.ApplicationUserId = httpContextAccessor.GetUserId();



          


            await unitOfWork.GetRepository<Discount>().AddAsync(discount);
            await unitOfWork.SaveChangesAsync();

            var discountDTO = mapper.Map<DiscountDTO>(discount);

            return ResponseDTO<DiscountDTO>.Success(discountDTO, HttpStatusCode.Created);
        }


        public async Task<ResponseDTO<bool>> DeleteDiscountAsync(int discountId)
        {
            var userId = httpContextAccessor.GetUserId();
            var discount = await unitOfWork.GetRepository<Discount>().GetByIdAsync(discountId);

            if (discount == null)
            {
                return ResponseDTO<bool>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Discount not found.",
                Code = "DISCOUNT_NOT_FOUND",
                Target = nameof(discountId)
            }
        }, HttpStatusCode.NotFound);
            }
            if (discount.ApplicationUserId != userId)
            {
                return ResponseDTO<bool>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "You can only apply discounts to your own products.",
                Code = "UNAUTHORIZED",
                Target = nameof(Discount)
            }
        }, HttpStatusCode.Forbidden);
            }


            discount.IsActive = false;
            unitOfWork.GetRepository<Discount>().SoftDeleteAsync(discount);

            await unitOfWork.SaveChangesAsync();

            return ResponseDTO<bool>.Success(true, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<IEnumerable<DiscountDTO>>> GetAllDiscountsAsync()
        {
            var discounts = await unitOfWork.GetRepository<Discount>()
        .GetAllAsync(x => !x.IsDeleted);

            if (discounts == null || !discounts.Any())
            {
                return ResponseDTO<IEnumerable<DiscountDTO>>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "No active discounts found.",
                Code = "NO_ACTIVE_DISCOUNTS",
                Target = "Discounts"
            }
        }, HttpStatusCode.NotFound);
            }


            var discountDTOs = mapper.Map<List<DiscountDTO>>(discounts);

            return ResponseDTO<IEnumerable<DiscountDTO>>.Success(discountDTOs, HttpStatusCode.OK);
        }


        public async Task<ResponseDTO<DiscountDTO>> UpdateDiscountAsync(DiscountUptadeDTO discountUpdateDTO)
        {
            var userId = httpContextAccessor.GetUserId();
            var discount = await unitOfWork.GetRepository<Discount>()
           .GetAsync(x => x.Id == discountUpdateDTO.Id && !x.IsDeleted);

            if (discount == null)
            {
                return ResponseDTO<DiscountDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Discount not found or has been deleted.",
                Code = "DISCOUNT_NOT_FOUND",
                Target = "DiscountId"
            }
        }, HttpStatusCode.NotFound);
            }
            if (discount.ApplicationUserId != userId)
            {
                return ResponseDTO<DiscountDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "You can only apply discounts to your own products.",
                Code = "UNAUTHORIZED",
                Target = nameof(Discount)
            }
        }, HttpStatusCode.Forbidden);
            }

            var updatedDiscount = mapper.Map(discountUpdateDTO, discount);
            unitOfWork.GetRepository<Discount>().UpdateAsync(updatedDiscount);
            await unitOfWork.SaveChangesAsync();

            var discountDTO = mapper.Map<DiscountDTO>(updatedDiscount);

            return ResponseDTO<DiscountDTO>.Success(discountDTO, HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<IEnumerable<DiscountDTO>>> GetDiscountByCouponCodeAsync(string couponCode)
        {
            var discounts = await unitOfWork.GetRepository<Discount>().GetAsync(x => x.CouponCode == couponCode && x.IsActive && x.StartDate <= DateTime.Now && x.EndDate >= DateTime.Now);
            if (discounts == null)
            {
                return ResponseDTO<IEnumerable<DiscountDTO>>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "No active discounts found with this coupon code.",
                        Code = "NO_ACTIVE_DISCOUNTS",
                        Target = "CouponCode"
                    }
                }, HttpStatusCode.NotFound);

            }
            var discountDTOs = mapper.Map<List<DiscountDTO>>(discounts);
            return ResponseDTO<IEnumerable<DiscountDTO>>.Success(discountDTOs, HttpStatusCode.OK);

        }
        public async Task<ResponseDTO<IEnumerable<DiscountDTO>>> GetDiscountBySellerAsync()
        {
            var sellerId = httpContextAccessor.GetUserId(); 

            var discounts = await unitOfWork.GetRepository<Discount>().GetAllAsync(d=>d.ApplicationUserId== sellerId, null,null,false, query=>query.Include(d => d.Product));

            if (!discounts.Any())
            {
                return ResponseDTO<IEnumerable<DiscountDTO>>.Success(new List<DiscountDTO>(), HttpStatusCode.OK);
            }

            var discountDTOs = mapper.Map<IEnumerable<DiscountDTO>>(discounts); 

            return ResponseDTO<IEnumerable<DiscountDTO>>.Success(discountDTOs, HttpStatusCode.OK);
        }



        public async Task<ResponseDTO<IEnumerable<DiscountDTO>>> GetDiscountByProductIdAsync(int productId)
        {
            var product = await unitOfWork.GetRepository<Product>().GetByIdAsync(productId);
            if (product == null)
            {
                return ResponseDTO<IEnumerable<DiscountDTO>>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "Product not found.",
                        Code = "PRODUCT_NOT_FOUND",
                        Target = "ProductId"
                    }
                }, HttpStatusCode.NotFound);
            }

            var discounts = await unitOfWork.GetRepository<Discount>().GetAllAsync(x =>x.ProductId==productId && x.IsActive && x.StartDate <= DateTime.Now && x.EndDate >= DateTime.Now);
            if (discounts == null || !discounts.Any())
            {
                return ResponseDTO<IEnumerable<DiscountDTO>>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "No active discounts found for this product.",
                        Code = "NO_ACTIVE_DISCOUNTS",
                        Target = "ProductId"
                    }
                }, HttpStatusCode.NotFound);
            }

            var discountDTOs = mapper.Map<List<DiscountDTO>>(discounts);
            return ResponseDTO<IEnumerable<DiscountDTO>>.Success(discountDTOs, HttpStatusCode.OK);
        }
    }
}