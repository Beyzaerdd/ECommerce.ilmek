using ECommerce.Shared.ComplexTypes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Reflection;
namespace ECommerce.MVC.Areas.Admin.Models.DiscountModels

    public class DiscountCreateModel
    {
        [Required(ErrorMessage = "İndirim adı zorunludur.")]
        [StringLength(100, ErrorMessage = "İndirim adı en fazla 100 karakter olabilir.")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "İndirim oranı zorunludur.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "İndirim oranı 0'dan büyük olmalıdır.")]
        [JsonPropertyName("discountValue")]
        public decimal DiscountValue { get; set; }

        [Required(ErrorMessage = "İndirim tipi zorunludur.")]
        [JsonPropertyName("type")]
        public DiscountType Type { get; set; }

        [Required(ErrorMessage = "Kupon kodu zorunludur.")]
        [StringLength(20, ErrorMessage = "Kupon kodu en fazla 20 karakter olabilir.")]
        [JsonPropertyName("couponCode")]
        public string CouponCode { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur.")]
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur.")]
        [DateGreaterThan("StartDate", ErrorMessage = "Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.")]
        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("productId")]
        public int? ProductId { get; set; }
    }
}
