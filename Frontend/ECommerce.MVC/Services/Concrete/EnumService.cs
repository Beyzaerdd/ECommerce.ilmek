using ECommerce.MVC.Models.EnumResponseModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using System.Text.Json;

namespace ECommerce.MVC.Services.Concrete
{
    public class EnumService :BaseService, IEnumService
    {
        public EnumService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor) { }

        private async Task<ResponseViewModel<IEnumerable<EnumResponseModel>>> GetEnumDataAsync(string endpoint)
        { //TODO  enum servis hazırlanacak
            var client = GetHttpClient();

            try
            {
                var response = await client.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    return new ResponseViewModel<IEnumerable<EnumResponseModel>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel>
                    {
                        new ErrorViewModel { Message = $"Veri getirilirken bir hata oluştu: {response.ReasonPhrase}" }
                    }
                    };
                }

                var responseBody = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(responseBody))
                {
                    return new ResponseViewModel<IEnumerable<EnumResponseModel>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel>
                    {
                        new ErrorViewModel { Message = "API'den geçerli veri alınamadı." }
                    }
                    };
                }

                var data = JsonSerializer.Deserialize<IEnumerable<EnumResponseModel>>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return data != null
                    ? new ResponseViewModel<IEnumerable<EnumResponseModel>> { IsSucceeded = true, Data = data }
                    : new ResponseViewModel<IEnumerable<EnumResponseModel>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel>
                        {
                        new ErrorViewModel { Message = "Veri işlenemedi." }
                        }
                    };
            }
            catch (Exception ex)
            {
                return new ResponseViewModel<IEnumerable<EnumResponseModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = $"Beklenmedik bir hata oluştu: {ex.Message}" }
                }
                };
            }
        }

        public async Task<ResponseViewModel<IEnumerable<EnumResponseModel>>> GetAvailableColorsAsync()
        {
            return await GetEnumDataAsync("products/colors");
        }

        public async Task<ResponseViewModel<IEnumerable<EnumResponseModel>>> GetAvailableSizesAsync()
        {
            return await GetEnumDataAsync("products/sizes");
        }

    }
}
