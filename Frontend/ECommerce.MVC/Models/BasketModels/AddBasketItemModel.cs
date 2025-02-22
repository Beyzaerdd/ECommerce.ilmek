using ECommerce.MVC.Models.EnumResponseModels;
using ECommerce.MVC.Models.ProductModels;
using ECommerce.Shared.ComplexTypes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.BasketModels
{
    public class AddBasketItemModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("basketId")]
        public int BasketId { get; set; }

        [Required]
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("product")]
        public ProductModel Product { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Miktar en az 1 olmalıdır.")]
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("originalPrice")]
        public decimal OriginalPrice { get; set; }

        [JsonPropertyName("discountedPrice")]
        public decimal DiscountedPrice { get; set; }

        [JsonPropertyName("size")]
        public ProductSize Size { get; set; }

        [JsonPropertyName("color")]
        public ProductColor Color { get; set; }
    }
}
