using ECommerce.MVC.Models.CategoryModels;
using ECommerce.MVC.Models.ProductModels;

namespace ECommerce.MVC.Models
{
    public class HomeIndexModel
    {
        
            public IEnumerable<CategoryModel> Categories { get; set; }
           
        
    }
}
