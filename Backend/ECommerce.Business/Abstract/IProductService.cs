﻿using ECommerce.Shared.DTOs.ProductDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IProductService
    {
        Task<ResponseDTO<ProductDTO>> AddProductAsync(ProductCreateDTO productCreateDTO);
        Task<ResponseDTO<NoContent>> UpdateProductAsync(ProductUpdateDTO productUpdateDTO);
        Task<ResponseDTO<NoContent>> SoftDeleteProductAsync(int id);
        Task<ResponseDTO<NoContent>> HardDeleteProductAsync(int id);

        Task<ResponseDTO<ProductDTO>> GetProductByIdAsync(int id);
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetAllProductsAsync();

        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetProductsWithCategoriesAsync(int parentCategoryId);
        Task<ResponseDTO<IEnumerable<ProductDTO>>> GetProductsBySubCategoryIdAsync(int subCategoryId);

        Task<ResponseDTO<int>> GetProductCountAsync(bool? isActive);
       

        Task<ResponseDTO<int>> GetCountBySubCategory(int subCategoryId);



    }
}
