using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs.OrderDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IOrderService
    {
        Task<ResponseDTO<OrderDTO>> GetOrderAsync(int id);
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync();
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(OrderStatus orderStatus);
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(string applicationUserId);
        Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersAsync(DateTime startDate, DateTime endDate);
        Task<ResponseDTO<IEnumerable<OrderDTO>>> CreateOrderAsync(OrderCreateDTO orderCreateDTO);
        Task<ResponseDTO<NoContent>> UpdateOrderAsync(OrderUpdateDTO orderUpdateDTO);
        Task<ResponseDTO<NoContent>> DeleteOrderAsync(int id);
        
       Task<ResponseDTO<IEnumerable<OrderDTO>>> GetOrdersBySellerIdAsync(string sellerId);

        Task<ResponseDTO<NoContent>> UpdateOrderStatusAsync(int orderId, OrderStatus orderStatus);




    }
}
