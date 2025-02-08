using ECommerce.Business.Abstract;
using ECommerce.Shared.DTOs.ProductDTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

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
        public async Task<IActionResult> CreateProduct([FromForm]ProductCreateDTO productCreateDTO )
        {
        

            var response = await _productService.AddProductAsync(productCreateDTO);
            return CreateResponse(response);
        }

        [Authorize(Policy = "SellerAndAdmin")]
        [HttpPut]
        
        public async Task<IActionResult> UpdateProduct([FromForm] ProductUpdateDTO productUpdateDTO )
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

        [HttpGet("GetProductBy/{id}")]
   
        public async Task<IActionResult> GetProductById([FromRoute] int id)
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

        [HttpGet("getWithCategories/{categoryId}")]
      
        public async Task<IActionResult> GetProductsByCategory([FromRoute] int categoryId)
        {
            var response = await _productService.GetProductsWithCategoriesAsync(categoryId);
            return CreateResponse(response);
        }

        [HttpGet("getByCategory/{categoryId}")]
       
        public async Task<IActionResult> GetProductsByCategoryId([FromRoute] int categoryId)
        {
            var response = await _productService.GetProductsByCategoryIdAsync(categoryId);
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
        [HttpGet("getCountByCategory/{categoryId}")]

        public async Task<IActionResult> GetCountByCategory([FromRoute] int categoryId)
        {
            var response = await _productService.GetCountByCategory(categoryId);
            return CreateResponse(response);
        }




        [HttpGet("filterProducts")]
        public async Task<IActionResult> FilterProducts(int categoryId,[FromQuery] List<int>? productSizes, [FromQuery] List<int>? productColors, decimal? minPrice, decimal? maxPrice)
        {
            var response = await _productService.FilterProducts(categoryId, productSizes, productColors, minPrice, maxPrice);
            return CreateResponse(response);
        }


    }
}
