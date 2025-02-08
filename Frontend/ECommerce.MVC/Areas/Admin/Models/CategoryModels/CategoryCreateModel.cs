using ECommerce.MVC.Shared.Validations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.MVC.Areas.Admin.Models.CategoryModels
{
    public class CategoryCreateModel
    {
        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(30, ErrorMessage = "Kategori adı en fazla 30 karakter olabilir.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public int? ParentCategoryId { get; set; }

        [Required(ErrorMessage = "Lütfen bir resim yükleyin.")]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg" })]
        [MaxFileSize(5 * 1024 * 1024)]
        public IFormFile Image { get; set; }
    }
}
