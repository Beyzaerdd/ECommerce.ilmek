﻿using ECommerce.Shared.ComplexTypes;
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

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("availableSizes")]
        public List<ProductSize> AvailableSizes { get; set; } = new();

        [JsonPropertyName("availableColors")]
        public List<ProductColor> AvailableColors { get; set; } = new();

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
        public IFormFile Image { get; set; }
    }
}
