using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.MVC.Models.ProductModels
{
    public class ProductFilterComponentModel
    {
        public int MinPrice { get; set; } = 0;
        public int MaxPrice { get; set; } = 100;

     
        public int SelectedSize { get; set; } = 0;  
        public int SelectedColor { get; set; } = 0; 

        public List<SelectListItem> AvailableSizes { get; set; }
        public List<SelectListItem> AvailableColors { get; set; }
    }
}
