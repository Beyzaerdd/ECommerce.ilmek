using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.DTOs
{
    public class CategoryUpdateDTO
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
