using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models.CategoryModels
{
    public class CategoryModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("productCount")]
        public int ProductCount { get; set; }

        [JsonPropertyName("parentCategoryId")]
        public int? ParentCategoryId { get; set; }

        [JsonPropertyName("parentCategoryName")]
        public string ParentCategoryName { get; set; }

        [JsonPropertyName("subCategories")]
        public List<CategoryModel> SubCategories { get; set; } = new List<CategoryModel>();
    }
}
