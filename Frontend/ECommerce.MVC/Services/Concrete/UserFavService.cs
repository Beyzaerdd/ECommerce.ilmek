using ECommerce.MVC.Models.UserFavModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.ResponseDTOs;
using System.Text.Json;

namespace ECommerce.MVC.Services.Concrete
{
    public class UserFavService:BaseService,IUserFavService
    {
        public UserFavService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ResponseViewModel<UserFavCreateModel>> AddToFavoritesAsync(UserFavCreateModel userFavCreateModel)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("UserFavs/addToFavorite", userFavCreateModel);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<UserFavCreateModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Favorilere eklenirken hata oluştu." }
            }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<UserFavCreateModel>>(responseBody, _jsonSerializerOptions);
            return result ?? new ResponseViewModel<UserFavCreateModel>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
            };
        }

        public async Task<ResponseViewModel<int>> GetFavoriteCountAsync(string applicationUserId)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"UserFavs/getFavoriteCount?applicationUserId={applicationUserId}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<int>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Favori sayısı alınırken hata oluştu." }
            }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<int>>(responseBody, _jsonSerializerOptions);
            return result ?? new ResponseViewModel<int>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
            };
        }

        public async Task<ResponseViewModel<IEnumerable<UserFavModel>>> GetUserFavoritesAsync(int? take = null)
        {
            
            var client = GetHttpClient();
            var response = await client.GetAsync("UserFavs/getUserFav");
            var responseBody = await response.Content.ReadAsStringAsync();
           

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<IEnumerable<UserFavModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Favori ürünler alınırken hata oluştu." }
            }
                };
            }

            var result = JsonSerializer.Deserialize<ResponseViewModel<IEnumerable<UserFavModel>>>(responseBody, _jsonSerializerOptions);
            return result ?? new ResponseViewModel<IEnumerable<UserFavModel>>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
            };
        }
        public async Task<ResponseViewModel<NoContentViewModel>> RemoveFromFavoritesAsync(int favId)
        {
            var client = GetHttpClient();
            var response = await client.DeleteAsync($"UserFavs/Remove?favId={favId}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Favori ürünü silerken hata oluştu." }
            },
                    Data = null // Burada Data'yı null döndürebilirsiniz
                };
            }

            // Eğer başarılıysa, ResponseDTO'nun içeriğini dönüşüm yaparak ResponseViewModel'e çevirin.
            var apiResponse = JsonSerializer.Deserialize<ResponseDTO<NoContent>>(responseBody, _jsonSerializerOptions);

            if (apiResponse != null && apiResponse.IsSucceeded)
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = true,
                    Errors = new List<ErrorViewModel>(),
                    Data = new NoContentViewModel() // Veritabanındaki işlem başarılı ise NoContentViewModel döndürülür.
                };
            }

            return new ResponseViewModel<NoContentViewModel>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel>
        {
            new ErrorViewModel { Message = apiResponse?.Errors?.FirstOrDefault()?.Message ?? "Hata oluştu." }
        },
                Data = null
            };
        }


    }
}
