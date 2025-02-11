
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace ECommerce.MVC.Models.AuthModels
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        [JsonPropertyName("currentpassword")]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Yeni şifre en az 8 karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
ErrorMessage = "Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.")]
        [JsonPropertyName("newpassword")]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Yeni şifreler eşleşmiyor.")]
        [JsonPropertyName("confirmnewpassword")]
        public string ConfirmNewPassword { get; set; }

    }
}
