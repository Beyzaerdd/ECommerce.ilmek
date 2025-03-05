using System.Text;
using System.Text.Json;
using ECommerce.MVC.Areas.Admin.Models.DiscountModels;
using ECommerce.MVC.Areas.Admin.Services.Abstract;
using ECommerce.MVC.Areas.Admin.Views.Shared.ResponseViewModels;
using ECommerce.MVC.Models.DiscountModels;
using ECommerce.MVC.Services.Abstract;

namespace ECommerce.MVC.Areas.Admin.Services.Concrete
{
    public class DiscountService : BaseService, IDiscountService
    {
        private readonly IEnumService _enumService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public DiscountService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IEnumService enumService)
            : base(httpClientFactory, httpContextAccessor)
        {
            _enumService = enumService;
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ResponseViewModel<DiscountModel>> CreateCouponCodeAsync(DiscountCreateModel discountCreateModel)
        {
            var client = GetHttpClient();
            var content = new StringContent(JsonSerializer.Serialize(discountCreateModel), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Discounts/createProduct", content);

            return await HandleResponse<DiscountModel>(response);
        }

        public async Task<ResponseViewModel<DiscountModel>> CreateProductDiscountAsync(DiscountCreateModel discountCreateModel)
        {
            var client = GetHttpClient();
            var content = new StringContent(JsonSerializer.Serialize(discountCreateModel), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Discounts/createProduct", content);

            return await HandleResponse<DiscountModel>(response);
        }

        public async Task<ResponseViewModel<bool>> DeleteDiscountAsync(int discountId)
        {
            var client = GetHttpClient();
            var response = await client.DeleteAsync($"Discounts/{discountId}");

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseViewModel<bool>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "İndirim silinirken bir hata oluştu." } }
                };
            }

            return new ResponseViewModel<bool> { IsSucceeded = true, Data = true };
        }

        public async Task<ResponseViewModel<IEnumerable<DiscountModel>>> GetAllDiscountsAsync()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("Discounts/getallDiscounts?isActive=true");

            return await HandleResponse<IEnumerable<DiscountModel>>(response);
        }

        public async Task<ResponseViewModel<IEnumerable<DiscountModel>>> GetDiscountByCouponCodeAsync(string couponCode)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"Discounts/getby/{couponCode}");

            return await HandleResponse<IEnumerable<DiscountModel>>(response);
        }

        public async Task<ResponseViewModel<IEnumerable<DiscountModel>>> GetDiscountByProductIdAsync(int productId)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"Discounts/getby/{productId}");

            return await HandleResponse<IEnumerable<DiscountModel>>(response);
        }

        public async Task<ResponseViewModel<IEnumerable<DiscountModel>>> GetDiscountBySellerAsync()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("Discounts/getDiscountBySeller");

            return await HandleResponse<IEnumerable<DiscountModel>>(response);
        }

        public async Task<ResponseViewModel<DiscountModel>> UpdateDiscountAsync(DiscountUpdateModel discountUpdateModel)
        {
            var client = GetHttpClient();
            var content = new StringContent(JsonSerializer.Serialize(discountUpdateModel), Encoding.UTF8, "application/json");
            var response = await client.PutAsync("Discounts", content);

            return await HandleResponse<DiscountModel>(response);
        }

        private async Task<ResponseViewModel<T>> HandleResponse<T>(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<T>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "İşlem sırasında bir hata oluştu." } }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<T>>(responseBody, _jsonSerializerOptions);
            return result ?? new ResponseViewModel<T>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
            };
        }
    }
}
