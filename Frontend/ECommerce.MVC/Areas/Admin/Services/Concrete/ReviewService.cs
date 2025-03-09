using ECommerce.MVC.Areas.Admin.Services.Abstract;
using ECommerce.MVC.Areas.Admin.Views.Shared.ResponseViewModels;
using ECommerce.MVC.Models.OrderModels;
using ECommerce.MVC.Models.ReviewModels;
using ECommerce.MVC.Services.Abstract;
using System.Security.Claims;
using System.Text.Json;

namespace ECommerce.MVC.Areas.Admin.Services.Concrete
{
    public class ReviewService:BaseService, Abstract.IReviewService
    {
        public ReviewService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor)
        {
           
        }

       
            public async Task<ResponseViewModel<IEnumerable<ReviewModel>>> GetReviewBySellerProducts()
            {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                {
                    return new ResponseViewModel<IEnumerable<ReviewModel>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Kullanıcı kimliği bulunamadı." }
            }
                    };
                }

                var client = GetHttpClient();
                var response = await client.GetAsync($"Reviews/getReviewsBySellerProducts?userId={userId}");

                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
                {
                    return new ResponseViewModel<IEnumerable<ReviewModel>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Yorumlar getirilirken bir hata oluştu." }
            }
                    };
                }

                var result = JsonSerializer.Deserialize<ResponseViewModel<IEnumerable<ReviewModel>>>(responseBody, _jsonSerializerOptions);

                return result ?? new ResponseViewModel<IEnumerable<ReviewModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
        {
            new ErrorViewModel { Message = "API'den geçerli veri alınamadı." }
        }
                };
            }





        }
    }

