using ECommerce.MVC.Models.BasketModels;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.OrderModels
{
    public class OrderCreateModel
    {
        [Required]
        [JsonProperty("applicationUserId")]
        public string ApplicationUserId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Sipariş en az bir ürün içermelidir.")]
        [JsonProperty("orderItems")]
        public List<OrderItemCreateModel> OrderItems { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Toplam fiyat sıfırdan büyük olmalıdır.")]
        [JsonProperty("totalPrice")]
        public decimal TotalPrice { get; set; }
        public IEnumerable<BasketItemModel> BasketItems { get; set; }
     
    }
}
