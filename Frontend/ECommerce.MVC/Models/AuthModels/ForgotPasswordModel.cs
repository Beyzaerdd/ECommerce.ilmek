using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.AuthModels
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
