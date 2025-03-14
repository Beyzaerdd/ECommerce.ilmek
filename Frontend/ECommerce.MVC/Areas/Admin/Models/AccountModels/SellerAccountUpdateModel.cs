using System.Text.Json.Serialization;

namespace ECommerce.MVC.Areas.Admin.Models.AccountModels
{
    public class SellerAccountUpdateModel
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("storename")]
        public string StoreName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("weeklyOrderLimit")]
        public int WeeklyOrderLimit { get; set; }
    }
}
