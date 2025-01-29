using ECommerce.Shared.DTOs;
using ECommerce.Shared.DTOs.CategoryDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ECommerce.Entity.Concrete;

namespace ECommerce.Business.Abstract
{
    public interface ICategoryService
    {
        
           
            Task<ResponseDTO<CategoryDTO>> AddCategoryAsync(CategoryCreateDTO categoryCreateDTO);
            Task<ResponseDTO<NoContent>> UpdateCategoryAsync(CategoryUpdateDTO categoryUpdateDTO);
            Task<ResponseDTO<NoContent>> SoftDeleteCategoryAsync(int id); // Soft delete
            Task HardDeleteCategoryAsync(int id); // Hard delete

            Task<ResponseDTO<CategoryDTO>> GetCategoryByIdAsync(int id);
            Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllCategoriesAsync();
            Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetCategoriesByParentIdAsync(int? parentId);

           Task<ResponseDTO<int>> GetCategoryCountAsync(bool? isActive);
           Task<ResponseDTO<int>> GetCategoryCountAsync();
            Task<ResponseDTO<bool>> AnyCategoryAsync(Expression<Func<Category, bool>> predicate);
        }

    }

