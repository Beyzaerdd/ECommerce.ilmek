using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.ReviewModels
{
    public class ReviewUpdateModel
    {
        [Required(ErrorMessage = "İçerik zorunludur.")]
        [MaxLength(500, ErrorMessage = "İçerik 500 karakteri geçemez.")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [Range(1, 5, ErrorMessage = "Puan 1 ile 5 arasında olmalıdır.")]
        [JsonPropertyName("rating")]
        public int? Rating { get; set; }
    }
}
