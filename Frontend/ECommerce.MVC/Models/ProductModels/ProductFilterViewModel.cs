using ECommerce.Shared.ComplexTypes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.MVC.Models.ProductModels
{
    public class ProductFilterViewModel
    {

        public int? CategoryId { get; set; }
        public List<int>? SelectedSizes { get; set; }
        public List<int>? SelectedColors { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string CategoryName { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
        public IEnumerable<ProductSize> AvailableSizes { get; set; }
        public IEnumerable<ProductColor> AvailableColors { get; set; }

        // Seçili bedenleri string formatına çeviren özellik
        public string SelectedSizesAsString => SelectedSizes != null ? string.Join(",", SelectedSizes) : "";
        public string SelectedColorsAsString => SelectedColors != null ? string.Join(",", SelectedColors) : "";
    }
    }


