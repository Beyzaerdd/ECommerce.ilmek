using ECommerce.Business.Abstract;
using ECommerce.Shared.DTOs.ProductDTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Policy = "SellerAndAdmin")]
        [HttpPost("AddProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDTO productCreateDTO)
        {
            var response = await _productService.AddProductAsync(productCreateDTO);
            return CreateResponse(response);
        }

        [Authorize(Policy = "SellerAndAdmin")]
        [HttpPut]
        
        public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateDTO productUpdateDTO)
        {
            var response = await _productService.UpdateProductAsync(productUpdateDTO);
            return CreateResponse(response);
        }

        [Authorize(Policy = "SellerAndAdmin")]
        [HttpDelete("softDelete/{id}")]
       
        public async Task<IActionResult> SoftDeleteProduct([FromRoute] int id)
        {
            var response = await _productService.SoftDeleteProductAsync(id);
            return CreateResponse(response);
        }

        [Authorize(Policy = "SellerAndAdmin")]
        [HttpDelete("hardDelete/{id}")]
       
        public async Task<IActionResult> HardDeleteProduct( [FromRoute] int id)
        {
            var response = await _productService.HardDeleteProductAsync(id);
            return CreateResponse(response);
        }

        [Authorize(Policy = "User")]
        [HttpGet("GetProductBy/{id}")]
   
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            return CreateResponse(response);
        }


        [Authorize(Policy = "User")]
        [HttpGet("getall")]
    
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetAllProductsAsync();
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpGet("getByCategory/{categoryId}")]
      
        public async Task<IActionResult> GetProductsByCategory([FromRoute] int categoryId)
        {
            var response = await _productService.GetProductsWithCategoriesAsync(categoryId);
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpGet("getBySubCategory/{subCategoryId}")]
       
        public async Task<IActionResult> GetProductsBySubCategory([FromRoute] int subCategoryId)
        {
            var response = await _productService.GetProductsBySubCategoryIdAsync(subCategoryId);
            return CreateResponse(response);
        }
        [Authorize(Policy = "SellerAndAdmin")]
        [HttpGet("getCount/{isActive}")]
       
        public async Task<IActionResult> GetProductCount([FromQuery] bool? isActive)
        {
            var response = await _productService.GetProductCountAsync(isActive);
            return CreateResponse(response);
        }

        [Authorize(Policy = "SellerAndAdmin")]
        [HttpGet("getCountBySubCategory/{subCategoryId}")]

        public async Task<IActionResult> GetCountByCategory([FromRoute] int subCategoryId)
        {
            var response = await _productService.GetCountBySubCategory(subCategoryId);
            return CreateResponse(response);
        }


        [Authorize(Policy = "User")]
        [HttpGet("getByColor/{productColor}")]

        public async Task<IActionResult> GetProductByColor([FromQuery] int productColor)
        {
            var response = await _productService.GetProductByColor(productColor);
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpGet("getByPriceRange/{minPrice}/{maxPrice}")]
        
        public async Task<IActionResult> GetProductByPriceRange([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var response = await _productService.GetProductByPriceRange(minPrice, maxPrice);
            return CreateResponse(response);
        }
        [Authorize(Policy = "User")]
        [HttpGet("getBySize/{productSize}")]
      
        public async Task<IActionResult> GetProductBySize([FromQuery] int productSize)
        {
            var response = await _productService.GetProductBySize(productSize);
            return CreateResponse(response);
        }

    }
}
