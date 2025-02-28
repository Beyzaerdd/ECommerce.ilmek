using ECommerce.MVC.Models.EnumResponseModels;
using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs.OrderDTOs;
using Newtonsoft.Json;

namespace ECommerce.MVC.Models.OrderModels
{
    public class OrderModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("applicationUserId")]
        public string ApplicationUserId { get; set; }

        [JsonProperty("applicationUserName")]
        public string ApplicationUserName { get; set; }

        [JsonProperty("status")]
        public EnumResponseModel Status { get; set; }

        [JsonProperty("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonProperty("orderItems")]
        public List<OrderItemModel> OrderItems { get; set; } = new List<OrderItemModel>();

        [JsonProperty("totalPrice")]
        public decimal TotalPrice { get; set; }

        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }
    }
}
