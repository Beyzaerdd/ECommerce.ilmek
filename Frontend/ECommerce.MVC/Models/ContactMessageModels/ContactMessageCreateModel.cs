using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.ContactMessageModels
{
    public class ContactMessageCreateModel
    {
        [Required(ErrorMessage = "Ad-Soyad zorunludur.")]
        [StringLength(100, ErrorMessage = "Ad-Soyad en fazla 100 karakter olabilir.")]
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Konu zorunludur.")]
        [StringLength(150, ErrorMessage = "Konu en fazla 150 karakter olabilir.")]
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj içeriği boş olamaz.")]
        [StringLength(1000, ErrorMessage = "Mesaj en fazla 1000 karakter olabilir.")]
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
