

using ECommerce.MVC.Models.OrderModels;
using ECommerce.MVC.Views.Shared.ResponseViewModels;
using ECommerce.Shared.DTOs.OrderDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;

namespace ECommerce.MVC.Services.Abstract
{
    public interface IOrderService
    {
        Task<ResponseViewModel<IEnumerable<OrderCreateModel>>> CreateOrderAsync();
        Task<ResponseViewModel<IEnumerable<OrderModel>>> GetOrdersAsync(string applicationUserId);
        Task<ResponseViewModel<OrderModel>> GetOrderAsync(string id);
    }
}

