﻿using ECommerce.Shared.ComplexTypes;
using ECommerce.Shared.DTOs.DiscountDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public List<ProductSize> AvailableSizes { get; set; }
        public List<ProductColor> AvailableColors { get; set; }
        public string ApplicationUserId { get; set; }
        public int Stock { get; set; }
        public int PreparationTimeInDays { get; set; }
        public bool IsActive { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<DiscountDTO> Discounts { get; set; }
    }
}
