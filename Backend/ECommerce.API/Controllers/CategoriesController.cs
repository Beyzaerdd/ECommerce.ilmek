using ECommerce.Business.Abstract;
using ECommerce.Shared.DTOs.CategoryDTOs;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateDTO categoryCreateDTO)
        {
            var response = await _categoryService.AddCategoryAsync(categoryCreateDTO);
            return CreateResponse(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _categoryService.GetAllCategoriesAsync();
            return CreateResponse(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var response = await _categoryService.GetCategoryByIdAsync(id);
            return CreateResponse(response);
        }

        [HttpGet("getByParentId")]
        public async Task<IActionResult> GetCategoriesByParentId(int? parentId)
        {
            var response = await _categoryService.GetCategoriesByParentIdAsync(parentId);
            return CreateResponse(response);
        }

        [HttpPut("updateCategory")]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
        {
            var response = await _categoryService.UpdateCategoryAsync(categoryUpdateDTO);
            return CreateResponse(response);

           
        }

        [HttpDelete("softDelete/{id}")]
        public async Task<IActionResult> SoftDeleteCategory(int id)
        {
            var response = await _categoryService.SoftDeleteCategoryAsync(id);
            return CreateResponse(response);
        }

        [HttpDelete("hardDelete/{id}")]
        public async Task<IActionResult> HardDeleteCategory(int id)
        {
            await _categoryService.HardDeleteCategoryAsync(id);
            return NoContent();
        }

        [HttpGet("count/{isActive?}")]
        public async Task<IActionResult> GetCategoryCount(bool? isActive)
        {
            var response = await _categoryService.GetCategoryCountAsync(isActive);
            return CreateResponse(response);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var response = await _categoryService.GetCategoryCountAsync();
            return CreateResponse(response);
        }

        
    }
}
