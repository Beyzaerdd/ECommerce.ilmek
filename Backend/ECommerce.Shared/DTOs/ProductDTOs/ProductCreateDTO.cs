using ECommerce.Shared.ComplexTypes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }

        public int Stock {  get; set; }
    
        public List<ProductSize> AvailableSizes { get; set; }
        public List<ProductColor> AvailableColors { get; set; }

        public int PreparationTimeInDays { get; set; }
        public bool IsActive { get; set; }

        public int CategoryId { get; set; }
       public string? ImageUrl { get; set; }
        public IFormFile Image { get; set; }
    }
}
