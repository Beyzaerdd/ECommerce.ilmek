using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.ReviewModels
{
    public class ReviewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("orderItemId")]
        public int OrderItemId { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("rating")]
        public int? Rating { get; set; }

        [JsonPropertyName("orderItemProductName")]
        public string OrderItemProductName { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("productName")]
        public string? ProductName { get; set; } // ✅ Ürün Adı güncellendi

        [JsonPropertyName("productImageUrl")]
        public string? ProductImageUrl { get; set; } // ✅ Ürün görsel URL'si eklendi
        [JsonPropertyName("customerName")]
        public string CustomerName { get; set; }  // Yorum yapanın adı

        [JsonPropertyName("customerEmail")]
        public string? CustomerEmail { get; set; }
    }
}
