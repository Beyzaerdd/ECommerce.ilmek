﻿using ECommerce.MVC.Models.ReviewModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.ResponseDTOs;
using System.Text.Json;

namespace ECommerce.MVC.Services.Concrete
{
    public class ReviewService :BaseService, IReviewService
    {
        public ReviewService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ResponseViewModel<NoContent>> AddReviewAsync(ReviewCreateModel reviewCreateModel)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("reviews/addReview", reviewCreateModel);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<NoContent>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Yorum eklenirken bir hata oluştu." }
            }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<NoContent>>(responseBody, _jsonSerializerOptions);
            return result ?? new ResponseViewModel<NoContent> { IsSucceeded = false, Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } } };
        }

        public async Task<ResponseViewModel<NoContent>> DeleteReviewAsync(int reviewId)
        {
            var client = GetHttpClient();
            var response = await client.DeleteAsync($"reviews/delete?reviewId={reviewId}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<NoContent>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Yorum silinirken bir hata oluştu." }
            }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<NoContent>>(responseBody, _jsonSerializerOptions);
            return result ?? new ResponseViewModel<NoContent> { IsSucceeded = false, Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } } };
        }

        public async Task<ResponseViewModel<IEnumerable<ReviewModel>>> GetReviewByProductIdAsync(int productId)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"reviews/getByProductId?productId={productId}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<IEnumerable<ReviewModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Ürüne ait yorumlar alınırken hata oluştu." }
            }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<IEnumerable<ReviewModel>>>(responseBody, _jsonSerializerOptions);
            return result ?? new ResponseViewModel<IEnumerable<ReviewModel>> { IsSucceeded = false, Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } } };
        }

        public async Task<ResponseViewModel<NoContent>> UpdateReviewAsync(ReviewUpdateModel reviewUpdateModel)
        {
            var client = GetHttpClient();
            var response = await client.PutAsJsonAsync("reviews/update", reviewUpdateModel);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<NoContent>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Yorum güncellenirken bir hata oluştu." }
            }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<NoContent>>(responseBody, _jsonSerializerOptions);
            return result ?? new ResponseViewModel<NoContent> { IsSucceeded = false, Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } } };
        }

    }
}
