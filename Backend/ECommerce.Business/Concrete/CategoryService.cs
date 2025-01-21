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
            var newCategory = mapper.Map<Category>(categoryCreateDTO);
            newCategory.CreatedAt = DateTime.Now;
            newCategory.IsActive = true;

           
            await unitOfWork.GetRepository<Category>().AddAsync(newCategory);
            await unitOfWork.SaveChangesAsync();
            var categoryDTO = mapper.Map<CategoryDTO>(newCategory);

            return ResponseDTO<CategoryDTO>.Success(categoryDTO, HttpStatusCode.Created);
        }


    }

}

}
