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
    public class ProductUptadeDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than zero.")]
        public decimal UnitPrice { get; set; }



        [Range(0, int.MaxValue, ErrorMessage = "Preparation time must be a non-negative value.")]
        public int PreparationTimeInDays { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }
        public int? SubcategoryId { get; set; }

        public IFormFile Image { get; set; }
    }
}
