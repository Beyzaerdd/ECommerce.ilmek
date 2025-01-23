using AutoMapper;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.CategoryDTOs;
using ECommerce.Shared.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Category
            CreateMap<Category, CategoryDTO>()
                .ForMember(src => src.ParentCategoryName, opt => opt.MapFrom(dest => dest.ParentCategory.Name)).ReverseMap();
           
              //  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ParentCategoryName));
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();


            #endregion
            #region Product
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
           
            #endregion
        }
    }
}