using ECommerce.MVC.Models.BasketModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.BasketDTOs;
using Newtonsoft.Json;

namespace ECommerce.MVC.Services.Concrete
{
    public class BasketService : BaseService, IBasketService
    {
        public BasketService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ResponseViewModel<BasketItemModel>> AddProductToBasketAsync(BasketItemModel basketItemModel)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("baskets/addProductToBasket", basketItemModel);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<BasketItemModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Ürün sepete eklenirken bir hata oluştu." }
                }
                };
            }

            var result = JsonConvert.DeserializeObject<ResponseViewModel<BasketItemModel>>(responseBody);
            return result!; throw new NotImplementedException();
        }

        public async Task<ResponseViewModel<decimal>> CalculateTotalAmountAsync()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("baskets/calculateTotalAmount");

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseViewModel<decimal>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Toplam tutar hesaplanırken bir hata oluştu." }
                }
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ResponseViewModel<decimal>>();
            return result!;
        }
    
        public async Task<ResponseViewModel<NoContentViewModel>> ChangeProductQuantityAsync(BasketItemChangeQuantityModel basketItemChangeQuantityModel)
        {
            var client = GetHttpClient();
            var response = await client.PutAsJsonAsync("baskets/changeProductQuantity", basketItemChangeQuantityModel);

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Ürün adedi güncellenirken bir hata oluştu." }
                }
                };
              
            }
            return new ResponseViewModel<NoContentViewModel> { IsSucceeded = true };
        }
        public async Task<ResponseViewModel<NoContentViewModel>> ClearBasketAsync()
        {
            var client = GetHttpClient();
            var response = await client.DeleteAsync("baskets/clearBasket");

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Sepet temizlenirken bir hata oluştu." }
}
                };
            }

            return new ResponseViewModel<NoContentViewModel> { IsSucceeded = true };
        }

        public async Task<ResponseViewModel<NoContentViewModel>> CreateBasketAsync(BasketModel basketModel)
        {
            var client = GetHttpClient();
            var response = await client.PostAsJsonAsync("baskets", basketModel);

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Sepet oluşturulurken bir hata oluştu." }
            }
                };
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Sunucudan geçersiz yanıt alındı." }
            }
                };
            }

            try
            {
                var result = JsonConvert.DeserializeObject<ResponseViewModel<BasketModel>>(responseBody);
                return new ResponseViewModel<NoContentViewModel> { IsSucceeded = result!.IsSucceeded };
            }
            catch (JsonException)
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Yanıt verisi çözümlenemedi." }
            }
                };
            }
        }


        public async Task<ResponseViewModel<BasketModel>> GetBasketAsync()
        {
            var client = GetHttpClient();
            var response = await client.GetAsync("baskets/getBasket");

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseViewModel<BasketModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Sepet getirilirken bir hata oluştu." }
                }
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ResponseViewModel<BasketModel>>();
            return result!;
        }


        public async  Task<ResponseViewModel<NoContentViewModel>> RemoveProductFromBasketAsync(int basketItemId)
        {
            var client = GetHttpClient();
            var response = await client.DeleteAsync($"baskets/removeProductFromBasket/{basketItemId}");

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
                {
                    new ErrorViewModel { Message = "Ürün sepetten çıkarılırken bir hata oluştu." }
                }
                };
            }

            return new ResponseViewModel<NoContentViewModel> { IsSucceeded = true };
        }
    }
}
