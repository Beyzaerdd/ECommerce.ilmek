using ECommerce.MVC.Areas.Admin.Models.DiscountModels;
using ECommerce.MVC.Models.EnumResponseModels;
using ECommerce.Shared.ComplexTypes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Areas.Admin.Models.ProductModels
{
    public class ProductUpdateModel
    {
        [Required(ErrorMessage = "Ürün ID zorunludur.")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        [StringLength(200, ErrorMessage = "Ürün adı en fazla 200 karakter olabilir.")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

       
        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("availableSizes")]
        public List<EnumResponseModel>? AvailableSizes { get; set; } = new();

        [JsonPropertyName("availableColors")]
        public List<EnumResponseModel>? AvailableColors { get; set; } = new();

        [Required(ErrorMessage = "Hazırlık süresi zorunludur.")]
        [Range(0, int.MaxValue, ErrorMessage = "Hazırlık süresi negatif olamaz.")]
        [JsonPropertyName("preparationTimeInDays")]
        public int PreparationTimeInDays { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Kategori ID zorunludur.")]
        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

    
        [JsonPropertyName("stock")]
        public int Stock { get; set; }

        [JsonPropertyName("image")]
        public IFormFile? Image { get; set; }

        [JsonPropertyName("availableSizeIds")]
        public List<int> AvailableSizeIds { get; set; } = new();

        [JsonPropertyName("availableColorIds")]
        public List<int> AvailableColorIds { get; set; } = new();


        [JsonPropertyName("imageUrl")] // API'den gelen ImageUrl'yi karşılamak için
        public string? ImageUrl { get; set; }
        public DiscountUpdateModel? Discount { get; set; }

    }
}
