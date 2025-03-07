using ECommerce.Shared.ComplexTypes;

using System.Text.Json.Serialization;

using ECommerce.MVC.Models.DiscountModels;
using ECommerce.MVC.Models.EnumResponseModels;




namespace ECommerce.MVC.Models.ProductModels
{
    public class ProductModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }
        [JsonPropertyName("stock")]
        public int Stock { get; set; } 
        [JsonPropertyName("availableSizes")] 
        public List<int> AvailableSizeIds { get; set; } = new();

        [JsonPropertyName("availableColors")] 
        public List<int> AvailableColorIds { get; set; } = new();

       
        public List<EnumResponseModel> Sizes { get; set; } = new();
        public List<EnumResponseModel> Colors { get; set; } = new();



        [JsonPropertyName("applicationUserId")]
        public string ApplicationUserId { get; set; }

        [JsonPropertyName("preparationTimeInDays")]
        public int PreparationTimeInDays { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("categoryName")]
        public string CategoryName { get; set; }

        [JsonPropertyName("categoryId")]
        public int CategoryId { get; set; }

        [JsonPropertyName("subCategoryName")]
        public string SubcategoryName { get; set; }

        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }
        [JsonPropertyName("storeName")]
        public string StoreName { get; set; }

        [JsonPropertyName("discounts")]
        public List<DiscountModel> Discounts { get; set; } = new List<DiscountModel>();

    }
}
