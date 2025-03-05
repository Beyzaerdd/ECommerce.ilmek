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
    public class ProductUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public List<ProductSize> AvailableSizes { get; set; }
        public List<ProductColor> AvailableColors { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Preparation time must be a non-negative value.")]
        public int PreparationTimeInDays { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }
    

        public IFormFile? Image { get; set; }
        public string ImageUrl { get; set; }
    }
}
