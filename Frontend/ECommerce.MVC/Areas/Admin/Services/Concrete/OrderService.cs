using ECommerce.MVC.Services.Abstract;

using ECommerce.MVC.Areas.Admin.Services.Abstract;
using IOrderService = ECommerce.MVC.Areas.Admin.Services.Abstract.IOrderService;
using ECommerce.MVC.Areas.Admin.Views.Shared.ResponseViewModels;
using ECommerce.MVC.Models.OrderModels;
using ECommerce.Shared.ComplexTypes;
using System.Text;
using System.Text.Json;
using System.Buffers.Text;
namespace ECommerce.MVC.Areas.Admin.Services.Concrete
{
    public class OrderService:BaseService, IOrderService
    {
        private readonly IEnumService enumService;
        public OrderService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor,IEnumService enumService) : base(httpClientFactory, httpContextAccessor)
        {
            this.enumService = enumService;
        } 

        public async Task<ResponseViewModel<NoContentViewModel>> DeleteOrderAsync(int id)
        {
            var client = GetHttpClient();
            var response = await client.DeleteAsync($"orders/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = "Sipariş silinirken bir hata oluştu." }
            }
                };
            }

            return new ResponseViewModel<NoContentViewModel> { IsSucceeded = true };
        }

        public async Task<ResponseViewModel<IEnumerable<OrderModel>>> GetOrdersBySellerIdAsync(string sellerId)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"orders/getOrdersBySeller/{sellerId}");

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

            var result = JsonSerializer.Deserialize<ResponseViewModel<IEnumerable<OrderModel>>>(responseBody, _jsonSerializerOptions);

            return result ?? new ResponseViewModel<IEnumerable<OrderModel>>
            {
                IsSucceeded = false,
                Errors = new List<ErrorViewModel>
        {
            new ErrorViewModel { Message = "API'den geçerli veri alınamadı." }
        }
            };
        }

        public async Task<ResponseViewModel<NoContentViewModel>> UpdateOrderStatusAsync(int orderId, OrderStatus orderStatus)
        {
            var client = GetHttpClient();

          
            var url = $"Orders/UpdateStatus/{orderId}";

        
            var content = new StringContent(JsonSerializer.Serialize(orderStatus), Encoding.UTF8, "application/json");

         
            var response = await client.PutAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var errorMessage = !string.IsNullOrEmpty(errorContent)
                                   ? JsonSerializer.Deserialize<ErrorViewModel>(errorContent)?.Message
                                   : "Sipariş durumu güncellenirken bir hata oluştu.";

                return new ResponseViewModel<NoContentViewModel>
                {
                    IsSucceeded = false,
                    Errors = new List<ErrorViewModel>
            {
                new ErrorViewModel { Message = errorMessage }
            }
                };
            }

            return new ResponseViewModel<NoContentViewModel> { IsSucceeded = true };
        }

       public async Task<ResponseViewModel<OrderModel>> GetOrderAsync(int id)
        {
            var client = GetHttpClient();
            var response = await client.GetAsync($"orders/getOrderBy/{id}");

            var responseBody = await response.Content.ReadAsStringAsync();

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

            var result = JsonSerializer.Deserialize<ResponseViewModel<OrderModel>>(responseBody, _jsonSerializerOptions);

            return result ?? new ResponseViewModel<OrderModel>
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

