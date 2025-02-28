using ECommerce.MVC.Models.EnumResponseModels;
using ECommerce.MVC.Models.ProductModels;
using ECommerce.Shared.ComplexTypes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.OrderModels
{
    public class OrderItemModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public int OrderItemId { get; set; }

        [JsonProperty("orderId")]
        public int OrderId { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("product")]
        public ProductModel Product { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("size")]
        public EnumResponseModel Size { get; set; }

        [JsonProperty("color")]
        public EnumResponseModel Color { get; set; }
    }
}
