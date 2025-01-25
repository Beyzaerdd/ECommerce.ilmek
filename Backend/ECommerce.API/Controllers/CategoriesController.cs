using ECommerce.Business.Abstract;
using ECommerce.Shared.DTOs.CategoryDTOs;
using ECommerce.Shared.DTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Policy = "SellerAndAdmin")]
        public async Task<IActionResult> CreateCategory(CategoryCreateDTO categoryCreateDTO)
        {
            var response = await _categoryService.AddCategoryAsync(categoryCreateDTO);
            return CreateResponse(response);
        }

        [HttpGet("getall")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _categoryService.GetAllCategoriesAsync();
            return CreateResponse(response);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var response = await _categoryService.GetCategoryByIdAsync(id);
            return CreateResponse(response);
        }

        [HttpGet("getByParentId")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> GetCategoriesByParentId(int? parentId)
        {
            var response = await _categoryService.GetCategoriesByParentIdAsync(parentId);
            return CreateResponse(response);
        }

        [HttpPut]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDTO categoryUpdateDTO)
        {
            var response = await _categoryService.UpdateCategoryAsync(categoryUpdateDTO);
            return CreateResponse(response);

           
        }
        [Authorize(Policy = "Admin")]
        [HttpDelete("softDelete/{id}")]
        public async Task<IActionResult> SoftDeleteCategory(int id)
        {
            var response = await _categoryService.SoftDeleteCategoryAsync(id);
            return CreateResponse(response);
        }
        [Authorize(Policy = "Admin")]
        [HttpDelete("hardDelete/{id}")]
        public async Task<IActionResult> HardDeleteCategory(int id)
        {
            await _categoryService.HardDeleteCategoryAsync(id);
            return NoContent();
        }
        [Authorize(Policy = "Admin")]
        [HttpGet("count/{isActive?}")]
        public async Task<IActionResult> GetCategoryCount(bool? isActive)
        {
            var response = await _categoryService.GetCategoryCountAsync(isActive);
            return CreateResponse(response);
        }
        [Authorize(Policy = "Admin")]
        [HttpGet("countAll")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var response = await _categoryService.GetCategoryCountAsync();
            return CreateResponse(response);
        }

        
    }
}
