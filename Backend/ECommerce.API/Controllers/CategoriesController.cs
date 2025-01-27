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

        [Authorize(Policy = "Admin")]
        [HttpPost]
        
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDTO categoryCreateDTO)
        {
            var response = await _categoryService.AddCategoryAsync(categoryCreateDTO);
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpGet("getall")]
        
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _categoryService.GetAllCategoriesAsync();
            return CreateResponse(response);
        }

        [Authorize(Policy = "User")]
        [HttpGet("{id}")]
       
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var response = await _categoryService.GetCategoryByIdAsync(id);
            return CreateResponse(response);
        }

        [HttpGet("getByParentId")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> GetCategoriesByParentId([FromQuery] int? parentId)
        {
            var response = await _categoryService.GetCategoriesByParentIdAsync(parentId);
            return CreateResponse(response);
        }
        [Authorize(Policy = "Admin")]
        [HttpPut]
     
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryUpdateDTO categoryUpdateDTO)
        {
            var response = await _categoryService.UpdateCategoryAsync(categoryUpdateDTO);
            return CreateResponse(response);

           
        }
        [Authorize(Policy = "Admin")]
        [HttpDelete("softDelete/{id}")]
        public async Task<IActionResult> SoftDeleteCategory([FromRoute] int id)
        {
            var response = await _categoryService.SoftDeleteCategoryAsync(id);
            return CreateResponse(response);
        }
        [Authorize(Policy = "Admin")]
        [HttpDelete("hardDelete/{id}")]
        public async Task<IActionResult> HardDeleteCategory([FromRoute] int id)
        {
            await _categoryService.HardDeleteCategoryAsync(id);
            return NoContent();
        }
        [Authorize(Policy = "Admin")]
        [HttpGet("count/{isActive?}")]
        public async Task<IActionResult> GetCategoryCount([FromQuery] bool? isActive)
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
