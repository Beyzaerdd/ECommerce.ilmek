using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.AuthModels
{
    public class LoginUserModel
    {
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [MinLength(8, ErrorMessage = "Lütfen şifrenizi doğru giriniz")]
        [DataType(DataType.Password)]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
