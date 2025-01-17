using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductCount { get; set; }
        public int ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set; }
        public List<CategoryDTO> SubCategories { get; set; } = new List<CategoryDTO>();
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
