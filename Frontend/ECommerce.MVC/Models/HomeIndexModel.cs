using ECommerce.MVC.Models.CategoryModels;
using ECommerce.MVC.Models.ProductModels;
using System.Text.Json.Serialization;

namespace ECommerce.MVC.Models
{
    public class HomeIndexModel
    {
        [JsonPropertyName("categories")]
        public IEnumerable<CategoryModel> Categories { get; set; }
           
        
    }
}
