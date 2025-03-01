using System.Text.Json.Serialization;

namespace ECommerce.MVC.Areas.Admin.Views.Shared.ResponseViewModels
{
    public class ErrorViewModel
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("code")]
        public string? Code { get; set; }

        [JsonPropertyName("target")]
        public string? Target { get; set; }
    }
}
