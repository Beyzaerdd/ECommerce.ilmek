using ECommerce.Business.Abstract;
using ECommerce.Shared.DTOs.ProductDTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDTO productCreateDTO)
        {
            var response = await _productService.AddProductAsync(productCreateDTO);
            return CreateResponse(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDTO productUpdateDTO)
        {
            var response = await _productService.UpdateProductAsync(productUpdateDTO);
            return CreateResponse(response);
        }
        [HttpDelete("softDelete/{id}")]
        public async Task<IActionResult> SoftDeleteProduct(int id)
        {
            var response = await _productService.SoftDeleteProductAsync(id);
            return CreateResponse(response);
        }
        [HttpDelete("hardDelete/{id}")]
        public async Task<IActionResult> HardDeleteProduct(int id)
        {
            var response = await _productService.HardDeleteProductAsync(id);
            return CreateResponse(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            return CreateResponse(response);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetAllProductsAsync();
            return CreateResponse(response);
        }
        [HttpGet("getByCategory/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var response = await _productService.GetProductsWithCategoriesAsync(categoryId);
            return CreateResponse(response);
        }
        [HttpGet("getBySubCategory/{subCategoryId}")]
        public async Task<IActionResult> GetProductsBySubCategory(int subCategoryId)
        {
            var response = await _productService.GetProductsBySubCategoryIdAsync(subCategoryId);
            return CreateResponse(response);
        }
        [HttpGet("getCount/{isActive}")]
        public async Task<IActionResult> GetProductCount(bool? isActive)
        {
            var response = await _productService.GetProductCountAsync(isActive);
            return CreateResponse(response);
        }
        [HttpGet("getCountBySubCategory/{subCategoryId}")]
        public async Task<IActionResult> GetCountByCategory(int subCategoryId)
        {
            var response = await _productService.GetCountBySubCategory(subCategoryId);
            return CreateResponse(response);
        }

       
        
    }
}
