using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.CategoryDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ResponseDTO<CategoryDTO>> AddCategoryAsync(CategoryCreateDTO categoryCreateDTO)
        {

            if (categoryCreateDTO.ParentCategoryId.HasValue && categoryCreateDTO.ParentCategoryId.Value > 0)
            {
                var ParentCategory = await unitOfWork.GetRepository<Category>().GetByIdAsync(categoryCreateDTO.ParentCategoryId.Value);

                if (ParentCategory == null)
                {
                    return ResponseDTO<CategoryDTO>.Fail(new List<ErrorDetail>
            {
                new ErrorDetail
                {
                    Message = $"Parent category not found with id: {categoryCreateDTO.ParentCategoryId}",
                    Code = "ParentCategoryNotFound",
                    Target = nameof(categoryCreateDTO.ParentCategoryId)
                }
            }, HttpStatusCode.BadRequest);
                }
            }

            if (await unitOfWork.GetRepository<Category>().AnyAsync(x => x.Name == categoryCreateDTO.Name))
            {
                return ResponseDTO<CategoryDTO>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = $"Category with name {categoryCreateDTO.Name} already exists",
                Code = "CategoryAlreadyExists",
                Target = nameof(categoryCreateDTO.Name)
            }
        }, HttpStatusCode.BadRequest);
            }

            var newCategory = mapper.Map<Category>(categoryCreateDTO);
            newCategory.CreatedAt = DateTime.Now;
            newCategory.IsActive = true;

            await unitOfWork.GetRepository<Category>().AddAsync(newCategory);
            await unitOfWork.SaveChangesAsync();
            var categoryDTO = mapper.Map<CategoryDTO>(newCategory);

            return ResponseDTO<CategoryDTO>.Success(categoryDTO, HttpStatusCode.Created);
        }

        public async Task<ResponseDTO<int>> GetCategoryCountAsync()
        {
            var count = await unitOfWork.GetRepository<Category>().CountAsync();
            return ResponseDTO<int>.Success(count, HttpStatusCode.OK);
        }
        public async Task<ResponseDTO<int>> GetCategoryCountAsync(bool? isActive)
        {
            var count = await unitOfWork.GetRepository<Category>().CountAsync(x => x.IsActive == isActive);
            return ResponseDTO<int>.Success(count, HttpStatusCode.OK);
        }


        public async Task<ResponseDTO<NoContent>> SoftDeleteCategoryAsync(int id)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByIdAsync(id);

            if (category == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message=$"Category not found with id: {id}",
                        Code="CategoryNotFound",
                        Target=nameof(id)
                    }
                }, HttpStatusCode.NotFound);
            }

            category.IsDeleted = true;
            unitOfWork.GetRepository<Category>().SoftDeleteAsync(category);
            await unitOfWork.SaveChangesAsync();

            return ResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task HardDeleteCategoryAsync(int id)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByIdAsync(id);

            if (category == null)
            {
                throw new InvalidOperationException($"Category not found with id: {id}");
            }

            if (category.IsDeleted == false)
            {
                throw new InvalidOperationException($"Category with id: {id} is not soft deleted");
            }

            unitOfWork.GetRepository<Category>().HardDeleteAsync(x => x.Id == id);
            await unitOfWork.SaveChangesAsync();

        }

        public async Task<ResponseDTO<CategoryDTO>> GetCategoryByIdAsync(int id)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByIdAsync(id);

            if (category == null)
            {
                return ResponseDTO<CategoryDTO>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message=$"Category not found with id: {id}",
                        Code="CategoryNotFound",
                        Target=nameof(id)
                    }
                }, HttpStatusCode.NotFound);
            }

            var categoryDTO = mapper.Map<CategoryDTO>(category);
            return ResponseDTO<CategoryDTO>.Success(categoryDTO, HttpStatusCode.OK);

        }

        public async Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetAllCategoriesAsync()
        {
            try
            {

                var categories = await unitOfWork.GetRepository<Category>().GetAllAsync();

                if (categories == null || !categories.Any())
                {
                    return ResponseDTO<IEnumerable<CategoryDTO>>.Fail(new List<ErrorDetail>
            {
                new ErrorDetail
                {
                    Message = "No categories found.",
                    Code = "CategoriesNotFound",
                    Target = nameof(categories)
                }
            }, HttpStatusCode.NotFound);
                }

                var categoryDTOs = mapper.Map<IEnumerable<CategoryDTO>>(categories);


                return ResponseDTO<IEnumerable<CategoryDTO>>.Success(categoryDTOs, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail
            {
                Message = $"An error occurred: {ex.Message}",
                Code = "InternalError",
                Target = "GetAllAsync"
            }
        }, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<ResponseDTO<NoContent>> UpdateCategoryAsync(CategoryUpdateDTO categoryUpdateDTO)
        {
            var category = await unitOfWork.GetRepository<Category>().GetByIdAsync(categoryUpdateDTO.Id);

            if (category == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message=$"Category not found with id: {categoryUpdateDTO.Id}",
                        Code="CategoryNotFound",
                        Target=nameof(categoryUpdateDTO.Id)
                    }
                }, HttpStatusCode.NotFound);
            }

            if (categoryUpdateDTO.ParentCategoryId > 0)
            {
                var ParentCategory = await unitOfWork.GetRepository<Category>().GetByIdAsync(categoryUpdateDTO.ParentCategoryId);

                if (ParentCategory == null)
                {
                    return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
                    {
                        new ErrorDetail
                        {
                            Message=$"Parent category not found with id: {categoryUpdateDTO.ParentCategoryId}",
                            Code="ParentCategoryNotFound",
                            Target=nameof(categoryUpdateDTO.ParentCategoryId)
                        }
                    }, HttpStatusCode.BadRequest);
                }
            }

            if (await unitOfWork.GetRepository<Category>().AnyAsync(x => x.Name == categoryUpdateDTO.Name && x.Id != categoryUpdateDTO.Id))
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message=$"Category with name {categoryUpdateDTO.Name} already exists",
                        Code="CategoryAlreadyExists",
                        Target=nameof(categoryUpdateDTO.Name)
                    }
                }, HttpStatusCode.BadRequest);
            }


            mapper.Map(categoryUpdateDTO, category);
            category.UpdatedAt = DateTime.Now;

            unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveChangesAsync();

            return ResponseDTO<NoContent>.Success(HttpStatusCode.NoContent);
        }

        public async Task<ResponseDTO<IEnumerable<CategoryDTO>>> GetCategoriesByParentIdAsync(int? parentId)
        {
            var categories = await unitOfWork.GetRepository<Category>()
                .GetAllAsync(
                    x => x.ParentCategoryId == parentId,
                          null,
                          null,
                          false,
                         query => query.Include(y => y.ParentCategory)
    );

            if (categories == null)
            {
                return ResponseDTO<IEnumerable<CategoryDTO>>.Fail(new List<ErrorDetail>
                {
                    new ErrorDetail
                    {
                        Message = "No categories found.",
                        Code = "CategoriesNotFound",
                        Target = nameof(categories)
                    }
                }, HttpStatusCode.NotFound);
            }
            var categoryDTOs = mapper.Map<IEnumerable<CategoryDTO>>(categories);

            return ResponseDTO<IEnumerable<CategoryDTO>>.Success(categoryDTOs, HttpStatusCode.OK);

        }

        public async Task<ResponseDTO<bool>> AnyCategoryAsync(Expression<Func<Category, bool>> predicate)
        {
            var any = await unitOfWork.GetRepository<Category>().AnyAsync(predicate);
            return ResponseDTO<bool>.Success(any, HttpStatusCode.OK);
        }


    }

}
