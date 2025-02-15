using ECommerce.MVC.Models.UserModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using System.Text.Json;

namespace ECommerce.MVC.Services.Concrete
{
    public class UserAccountManagerService:BaseService, IUserAccountManagerService
    {
        public UserAccountManagerService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ResponseViewModel<ApplicationUserModel>> GetSellerAccountDetails()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("UserAccountManagers/getSellerAccountDetails");
            return await HandleResponse<ApplicationUserModel>(response);
        }

        public async Task<ResponseViewModel<ApplicationUserModel>> GetUserAccountDetails()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("UserAccountManagers/getUserAccountDetails");
            return await HandleResponse<ApplicationUserModel>(response);
        }

        public async Task<ResponseViewModel<ApplicationUserModel>> GetUserByIdAsync(string userId)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"UserAccountManagers/getUserById?userId={userId}");


            Console.WriteLine($"API Status Code: {response.StatusCode}");

            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"API Yanıtı: {responseBody}");

            return await HandleResponse<ApplicationUserModel>(response);
        }
        public async Task<ResponseViewModel<ApplicationUserModel>> GetSellerByIdAsync(string sellerId)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"UserAccountManagers/getSellerById?sellerId={sellerId}");


            Console.WriteLine($"API Status Code: {response.StatusCode}");

            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"API Yanıtı: {responseBody}");

            return await HandleResponse<ApplicationUserModel>(response);
        }
        private async Task<ResponseViewModel<T>> HandleResponse<T>(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<T>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Sunucu hatası, lütfen tekrar deneyin." }
                }
                };
            }

            return JsonSerializer.Deserialize<ResponseViewModel<T>>(responseBody, _jsonSerializerOptions);
        }
    }
}
