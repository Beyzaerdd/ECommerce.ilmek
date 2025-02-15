using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.EnumResponseModels
{
    public class EnumResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
}
    
}
