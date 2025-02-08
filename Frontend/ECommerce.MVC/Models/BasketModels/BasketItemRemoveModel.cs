using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.BasketModels
{
    public class BasketItemRemoveModel
    {
        [Required]
        [JsonPropertyName("basketId")]
        public int BasketId { get; set; }

        [Required]
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }
    }
}
