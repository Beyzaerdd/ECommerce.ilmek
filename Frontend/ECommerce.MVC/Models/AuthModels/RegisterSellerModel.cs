using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.AuthModels
{
    public class RegisterSellerModel
    {
        [Required(ErrorMessage = "E-posta adresi boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Parola alanı boş bırakılamaz.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
ErrorMessage = "Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.")]
        [DataType(DataType.Password)]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Adres alanı boş bırakılamaz.")]
        [JsonPropertyName("address")]
        public string Address { get; set; }

     

        [Required(ErrorMessage = "Telefon numarası alanı boş bırakılamaz.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Telefon Numarası 11 haneli olmalıdır.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası girin.")]
        [JsonPropertyName("phonenumber")]
        public string PhoneNumber { get; set; }

   

        [Required(ErrorMessage = "Kimlik numarası alanı boş bırakılamaz.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Kimlik numarası 11 haneli olmalıdır.")]
        [JsonPropertyName("identitynumber")]
        public string IdentityNumber { get; set; }

        [Required(ErrorMessage = "Mağaza adı alanı boş bırakılamaz.")]
        [JsonPropertyName("storename")]
        public string StoreName { get; set; }

        [Required(ErrorMessage = "Haftalık sipariş alanı boş bırakılamaz.")]
        [JsonPropertyName("weeklyorderlimit")]
        [Range(0, 20, ErrorMessage = "Haftalık sipariş limiti 20'den fazla olamaz.")]
        public int WeeklyOrderLimit { get; set; }
    
    }
}
