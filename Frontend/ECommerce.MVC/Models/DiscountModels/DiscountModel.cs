using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.DiscountModels
{
    public class DiscountModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("discountValue")] // JSON'daki gerçek alan adını kontrol et
        public decimal DiscountValue { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
    }

}
