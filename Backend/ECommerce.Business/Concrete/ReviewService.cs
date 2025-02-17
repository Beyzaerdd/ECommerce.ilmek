using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.ReviewDTOs;
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
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        private readonly IMapper mapper;
        public async Task<ResponseDTO<NoContent>> AddReviewAsync(ReviewCreateDTO reviewCreateDTO)
        {
           
            var orderItem = await unitOfWork.GetRepository<OrderItem>()
                .GetAsync(oi => oi.Id == reviewCreateDTO.OrderItemId,
                          query => query.Include(oi => oi.Order.OrderItems)
                                        .ThenInclude(oi => oi.Product));

      
            var review = mapper.Map<Review>(reviewCreateDTO);
            review.OrderItemId = orderItem.Id; 
            review.OrderItem = orderItem;

          
            await unitOfWork.GetRepository<Review>().AddAsync(review);
            await unitOfWork.SaveChangesAsync();

            return ResponseDTO<NoContent>.Success(HttpStatusCode.Created);
        }


        public async Task<ResponseDTO<NoContent>> DeleteReviewAsync(int reviewId)
        {
            var user = httpContextAccessor.GetUserId();
         
            var review = await unitOfWork.GetRepository<Review>().GetAsync(r => r.Id == reviewId, query => query.Include(r => r.OrderItem).ThenInclude(r=>r.Order));

            
            if (review == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Review not found",
                Code = "NOT_FOUND",
                Target = "review"
            }
        }, HttpStatusCode.NotFound);
            }
            if (review.OrderItem.Order.ApplicationUserId != user)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "You do not have permission to delete this review",
                Code = "FORBIDDEN",
                Target = "review"
            }
        }, HttpStatusCode.Forbidden);
            }
            review.UpdatedAt = DateTime.Now;
            unitOfWork.GetRepository<Review>().SoftDeleteAsync(review);
            await unitOfWork.SaveChangesAsync();

            return ResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseDTO<IEnumerable<ReviewDTO>>> GetReviewByProductIdAsync(int productId)
        {
            var reviews = await unitOfWork.GetRepository<Review>()
                .GetAllAsync(
                    r => r.OrderItem != null && r.OrderItem.ProductId == productId, 
                    null,
                    null,
                    false,
                    query => query.Include(r => r.OrderItem) 
                                  .ThenInclude(oi => oi.Product) 
                );

            if (reviews == null || !reviews.Any())
            {
                return ResponseDTO<IEnumerable<ReviewDTO>>.Fail("Bu ürüne ait yorum bulunamadı.", HttpStatusCode.NotFound);
            }

            var result = mapper.Map<IEnumerable<ReviewDTO>>(reviews);
            return ResponseDTO<IEnumerable<ReviewDTO>>.Success(result, HttpStatusCode.OK);
        }



        public async Task<ResponseDTO<NoContent>> UpdateReviewAsync(ReviewUptadeDTO reviewUptadeDTO)
        {
            var user = httpContextAccessor.GetUserId();
            var review = await unitOfWork.GetRepository<Review>().GetAsync(r => r.Id == reviewUptadeDTO.Id,query=>query.Include(r=>r.OrderItem).ThenInclude(r=>r.Order));


            if (review == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "Review not found",
                Code = "NOT_FOUND",
                Target = "review"
            }
        }, HttpStatusCode.NotFound);
            }


            if (review.OrderItem.Order.ApplicationUserId != user)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = "You do not have permission to update this review",
                Code = "FORBIDDEN",
                Target = "review"
            }
        }, HttpStatusCode.Forbidden);
            }


            review.Content = reviewUptadeDTO.Content;
            review.Rating = reviewUptadeDTO.Rating;


            review.UpdatedAt = DateTime.Now;
            unitOfWork.GetRepository<Review>().UpdateAsync(review);
            await unitOfWork.SaveChangesAsync();

            return ResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);

        }
    }
}
