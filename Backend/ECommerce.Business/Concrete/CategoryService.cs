using AutoMapper;
using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.CategoryDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using Microsoft.AspNetCore.Http;
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
    public class CategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ResponseDTO<CategoryDTO>> AddAsync(CategoryCreateDTO categoryCreateDTO)
        {
            if (categoryCreateDTO.ParentCategoryId > 0)
            {

                var ParentCategory = await unitOfWork.GetRepository<Category>().GetByIdAsync(categoryCreateDTO.ParentCategoryId);

                if (ParentCategory == null)
                {
                    return ResponseDTO<CategoryDTO>.Fail(new List<ErrorDetail>
                    {
                        new ErrorDetail
                        {
                            Message=$"Parent category not found with id: {categoryCreateDTO.ParentCategoryId}",
                            Code="ParentCategoryNotFound",
                            Target=nameof(categoryCreateDTO.ParentCategoryId)
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
                        Message=$"Category with name {categoryCreateDTO.Name} already exists",
                        Code="CategoryAlreadyExists",
                        Target=nameof(categoryCreateDTO.Name)
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


        public async Task<ResponseDTO<int>> CountAsync()
        {
            var count = await unitOfWork.GetRepository<Category>().CountAsync();
            return ResponseDTO<int>.Success(count, HttpStatusCode.OK);
        }
        public async Task<ResponseDTO<int>> CountAsync(bool? isActive)
        {
            var count = await unitOfWork.GetRepository<Category>().CountAsync(x => x.IsActive == isActive);
            return ResponseDTO<int>.Success(count, HttpStatusCode.OK);
        }

     
        public async Task<ResponseDTO<NoContent>> SoftDeleteAsync(int id)
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

        public async Task HardDeleteIfSoftDeletedAsync(int id)
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


        }



    }




