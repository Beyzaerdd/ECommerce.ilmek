using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Models.CategoryModels
{
    public class CategoryUpdateModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(30, ErrorMessage = "Kategori adı en fazla 30 karakter olabilir.")]
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string ImageUrl { get; set; }
    }
}
