using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace ECommerce.MVC.Services.Abstract
{
    public abstract class BaseService
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly JsonSerializerOptions _jsonSerializerOptions;

        protected BaseService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };
        }

        protected HttpClient GetHttpClient()
        {
            var client = _httpClientFactory.CreateClient("ECommerceAPI");
            var token = _httpContextAccessor?.HttpContext?.User.FindFirstValue("AccessToken");
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }
    }
}