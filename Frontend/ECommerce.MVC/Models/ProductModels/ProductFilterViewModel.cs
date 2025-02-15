using ECommerce.Shared.ComplexTypes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.MVC.Models.ProductModels
{
    public class ProductFilterViewModel
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; } = "Kategori Bulunamadı"; 
        public List<int> SelectedSizes { get; set; } = new();
        public List<int> SelectedColors { get; set; } = new();
        public List<string> SelectedPriceRanges { get; set; } = new();
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public List<ProductModel> Products { get; set; } = new();
        public int TotalCount { get; set; }  
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }     
        public int TotalPages { get; set; }
        public List<SelectListItem> AvailableSizes { get; set; } = new();
        public List<SelectListItem> AvailableColors { get; set; } = new();
    }


}


