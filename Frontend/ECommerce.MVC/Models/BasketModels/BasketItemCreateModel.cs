using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.BasketModels
{
    public class BasketItemCreateModel
    {
        [Required]
        [JsonPropertyName("productid")]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Miktar en az 1 olmalıdır.")]
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
