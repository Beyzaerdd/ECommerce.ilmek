using ECommerce.MVC.Models.EnumResponseModels;
using ECommerce.Shared.ComplexTypes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.OrderModels
{
    public class OrderItemCreateModel
    {
        [Required(ErrorMessage = "Ürün ID boş olamaz.")]
        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Birim fiyat boş olamaz.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Birim fiyat geçerli bir değer olmalıdır.")]
        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Adet boş olamaz.")]
        [Range(1, int.MaxValue, ErrorMessage = "Ürün adedi en az 1 olmalıdır.")]
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Beden seçimi zorunludur.")]
        [JsonProperty("size")]
        public int Size { get; set; }

        [Required(ErrorMessage = "Renk seçimi zorunludur.")]
        [JsonProperty("color")]
        public int Color { get; set; }
    }
}
