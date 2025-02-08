using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.BasketModels
{
    public class BasketItemChangeQuantityModel
    {
        [Required]
        [JsonPropertyName("basketitemid")]
        public int BasketItemId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Miktar en az 1 olmalıdır.")]
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
