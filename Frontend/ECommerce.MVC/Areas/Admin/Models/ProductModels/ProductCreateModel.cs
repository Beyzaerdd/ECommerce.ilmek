using ECommerce.MVC.Models.EnumResponseModels;
using ECommerce.Shared.ComplexTypes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Areas.Admin.Models.ProductModels
{
    public class ProductCreateModel
    {
        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        [StringLength(200, ErrorMessage = "Ürün adı en fazla 200 karakter olabilir.")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("availableSizes")]
        public List<EnumResponseModel>? AvailableSizes { get; set; } = new();

        [JsonPropertyName("availableColors")]
        public List<EnumResponseModel>? AvailableColors { get; set; } = new();
        [JsonPropertyName("availableSizeIds")]
        public List<int> AvailableSizeIds { get; set; } = new();

        [JsonPropertyName("availableColorIds")]
        public List<int> AvailableColorIds { get; set; } = new();

        [Required(ErrorMessage = "Hazırlık süresi zorunludur.")]
        [Range(0, int.MaxValue, ErrorMessage = "Hazırlık süresi negatif olamaz.")]
        [JsonPropertyName("preparationTimeInDays")]
        public int PreparationTimeInDays { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Kategori ID zorunludur.")]
        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Ürün resmi zorunludur.")]
        [JsonPropertyName("image")]
        public IFormFile Image { get; set; }
        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }
        [Required(ErrorMessage = "Stok miktarı giriniz.")]
        [JsonPropertyName("stock")]
        public int Stock { get; set; }
    }
}
