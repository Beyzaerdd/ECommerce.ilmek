using ECommerce.MVC.Areas.Admin.Views.Shared.ResponseViewModels;
using ECommerce.MVC.Models.OrderModels;
using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs.OrderDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;

namespace ECommerce.MVC.Areas.Admin.Services.Abstract
{
    public interface IOrderService
    {
        Task<ResponseViewModel<IEnumerable<OrderModel>>> GetOrdersBySellerIdAsync(string sellerId);

        Task<ResponseViewModel<NoContentViewModel>> UpdateOrderStatusAsync(int orderId, OrderStatus orderStatus);
        Task<ResponseViewModel<NoContentViewModel>> DeleteOrderAsync(int id);
        Task<ResponseViewModel<OrderModel>> GetOrderAsync(int id);
    }
}
