using ECommerce.MVC.Models.BasketModels;
using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.BasketDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace ECommerce.MVC.Services.Concrete
{
    public class BasketService : BaseService, IBasketService
    {
        public BasketService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ResponseViewModel<BasketItemModel>> AddProductToBasketAsync(AddBasketItemModel addBasketItemModel)
        {
            var client = GetHttpClient();

           
            var response = await client.PostAsJsonAsync("baskets/addProductToBasket", addBasketItemModel);
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

            return new ResponseViewModel<BasketItemModel>
            {
                IsSucceeded = true

            };
        }


        public async Task<ResponseViewModel<decimal>> CalculateTotalAmountAsync()
        {
            var client = GetHttpClient();
            var fullUrl = new Uri(client.BaseAddress, "baskets/calculateTotalAmount");

            var response = await client.GetAsync(fullUrl);
            var responseBody = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
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

            try
            {
                var json = JObject.Parse(responseBody);
                decimal totalAmount = json["data"]?.Value<decimal>() ?? 0;

                return new ResponseViewModel<decimal>
                {
                    IsSucceeded = true,
                    Data = totalAmount
                };
            }
            catch (Exception ex)
            {
                return new ResponseViewModel<decimal>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
        {
            new ErrorViewModel { Message = "JSON çözümleme hatası: " + ex.Message }
        }
                };
            }
        }
            public async Task<ResponseViewModel<NoContentViewModel>> ChangeProductQuantityAsync(BasketItemChangeQuantityModel basketItemChangeQuantityModel)
        {
            var client = GetHttpClient();

 
            if (basketItemChangeQuantityModel.Quantity < 1)
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Miktar 1'den küçük olamaz." }
            }
                };
            }

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

            var result = await response.Content.ReadFromJsonAsync<ResponseViewModel<BasketModel>>();

            if (result == null || !result.IsSucceeded)
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Yanıt verisi çözümlenemedi veya sepet oluşturulamadı." }
            }
                };
            }

            return new ResponseViewModel<NoContentViewModel> { IsSucceeded = true };
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


        public async Task<ResponseViewModel<NoContentViewModel>> RemoveProductFromBasketAsync(int basketItemId)
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
