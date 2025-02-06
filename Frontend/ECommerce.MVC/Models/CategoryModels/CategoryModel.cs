using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.CategoryModels
{
    public class CategoryModel
    {
        public int Id { get; set; }

  
        public string Name { get; set; }

        public string Description { get; set; }

        public int ProductCount { get; set; }

        public int? ParentCategoryId { get; set; }

        public string ParentCategoryName { get; set; }

        public List<CategoryModel> SubCategories { get; set; } = new List<CategoryModel>();
    }
}
