using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.UserModels
{
    public class ApplicationUserModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Ad zorunludur.")]
        [MaxLength(100, ErrorMessage = "Ad 100 karakteri geçemez.")]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        [MaxLength(100, ErrorMessage = "Soyad 100 karakteri geçemez.")]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [MaxLength(500, ErrorMessage = "Adres 500 karakteri geçemez.")]
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [MaxLength(100, ErrorMessage = "Şehir adı 100 karakteri geçemez.")]
        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("storeName")]
        public string? StoreName { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isApproved")]
        public bool IsApproved { get; set; }

        [JsonPropertyName("identityNumber")]
        public string IdentityNumber { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("emailConfirmed")]
        public bool EmailConfirmed { get; set; }

        [Phone(ErrorMessage = "Geçerli bir telefon numarası girin.")]
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonPropertyName("weeklyOrderLimit")]
        public int WeeklyOrderLimit { get; set; }

    }
}
