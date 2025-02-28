using ECommerce.MVC.Models.OrderModels;
using ECommerce.MVC.Models.ProductModels;
using ECommerce.MVC.Services.Abstract;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ECommerce.MVC.Services.Concrete
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor) { }

        public async Task<ResponseViewModel<IEnumerable<OrderCreateModel>>> CreateOrderAsync()
        {
            var client = GetHttpClient();
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;


            var requestBody = new { applicationUserId = userId };
            var response = await client.PostAsJsonAsync("orders/createOrder", requestBody);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<IEnumerable<OrderCreateModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Sipariş oluşturulurken bir hata oluştu." }
            }
                };
            }

            var createdOrder = JsonConvert.DeserializeObject<OrderCreateModel>(responseBody);

            return new ResponseViewModel<IEnumerable<OrderCreateModel>>
            {
                IsSucceeded = true,
                Data = new List<OrderCreateModel> { createdOrder }
            };
        }

        public async Task<ResponseViewModel<IEnumerable<OrderModel>>> GetOrdersAsync(string applicationUserId)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"orders/user/{applicationUserId}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<IEnumerable<OrderModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Siparişler getirilirken bir hata oluştu." }
            }
                };
            }

            try
            {
            
                var result = JsonConvert.DeserializeObject<ResponseViewModel<IEnumerable<OrderModel>>>(responseBody);

                if (result == null || result.Data == null)
                {
                    return new ResponseViewModel<IEnumerable<OrderModel>>
                    {
                        IsSucceeded = false,
                        Errors = new List<ErrorViewModel> { new ErrorViewModel { Message = "API'den geçerli veri alınamadı." } }
                    };
                }

                return new ResponseViewModel<IEnumerable<OrderModel>>
                {
                    IsSucceeded = true,
                    Data = result.Data
                };
            }
            catch (JsonException ex)
            {
                return new ResponseViewModel<IEnumerable<OrderModel>>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = $"JSON deserialize hatası: {ex.Message}" }
            }
                };
            }
        }


        public async Task<ResponseViewModel<OrderModel>> GetOrderAsync(string id)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"orders/getOrderBy/{id}");
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);  

            if (!response.IsSuccessStatusCode || string.IsNullOrEmpty(responseBody))
            {
                return new ResponseViewModel<OrderModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Siparişler getirilirken bir hata oluştu." }
            }
                };
            }

            try
            {
                var order = JsonConvert.DeserializeObject<ResponseViewModel<OrderModel>>(responseBody);

                if (order == null)
                {
                    Console.WriteLine("Deserialization failed.");
                }
                else
                {
                    Console.WriteLine($"Order ID: {order.Data.Id}");  
                    return new ResponseViewModel<OrderModel>
                    {
                        IsSucceeded = true,
                        Data = order.Data
                    };
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON deserialization error: {ex.Message}");
                return new ResponseViewModel<OrderModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "JSON deserialization hatası." }
            }
                };
            }

       
            return new ResponseViewModel<OrderModel>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel>
        {
            new ErrorViewModel { Message = "Sipariş bulunamadı." }
        }
            };
        }


    }
}



