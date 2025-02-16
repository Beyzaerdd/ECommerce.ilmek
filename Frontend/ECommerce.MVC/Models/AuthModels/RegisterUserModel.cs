﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.AuthModels
{
    public class RegisterUserModel
    {

      

        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        [JsonPropertyName("firstname")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

      

        [Required(ErrorMessage = "Adres alanı boş bırakılamaz.")]
        [JsonPropertyName("adress")]
        public string Adress { get; set; }


        [Required(ErrorMessage = "E-posta adresi boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola alanı boş bırakılamaz.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
ErrorMessage = "Şifre en az bir büyük harf, bir küçük harf, bir rakam ve bir özel karakter içermelidir.")]

        [DataType(DataType.Password)]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        [JsonPropertyName("confirmpassword")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Telefon numarası alanı boş bırakılamaz.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Kimlik numarası 11 haneli olmalıdır.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası girin.")]
        [JsonPropertyName("phonenumber")]
        
        public string PhoneNumber { get; set; }
    }
}
