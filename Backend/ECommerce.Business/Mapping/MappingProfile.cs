using AutoMapper;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.AuthDTOs;
using ECommerce.Shared.DTOs.BasketDTOs;
using ECommerce.Shared.DTOs.CategoryDTOs;
using ECommerce.Shared.DTOs.ContactMessageDTOs;
using ECommerce.Shared.DTOs.DiscountDTOs;
using ECommerce.Shared.DTOs.InvoiceDTOs;
using ECommerce.Shared.DTOs.OrderDTOs;
using ECommerce.Shared.DTOs.ProductDTOs;
using ECommerce.Shared.DTOs.ReviewDTOs;
using ECommerce.Shared.DTOs.UserFavDTOs;
using ECommerce.Shared.DTOs.UsersDTO;
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
                .ForMember(src => src.ParentCategoryName, opt => opt.MapFrom(dest => dest.ParentCategory.Name))
                .ForMember(src => src.ProductCount, opt => opt.MapFrom(dest => dest.Products.Count()))
                .ReverseMap();
              //  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ParentCategoryName));
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();


            #endregion
            #region Product
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();

            #endregion
            #region Discount
            CreateMap<Discount, DiscountDTO>().ReverseMap();
            CreateMap<Discount, DiscountCreateDTO>().ReverseMap();
            CreateMap<Discount, DiscountUptadeDTO>().ReverseMap();
            #endregion

        

            #region Order
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderCreateDTO>().ReverseMap();
            CreateMap<Order, OrderUpdateDTO>().ReverseMap();
            #endregion

            #region OrderItem
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemCreateDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemUpdateDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>()
           .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems)); 

            
            #endregion



            #region Basket
            CreateMap<Basket, BasketDTO>().ReverseMap();
            CreateMap<Basket, BasketCreateDTO>().ReverseMap();
            CreateMap<Basket, BasketUpdateDTO>().ReverseMap();
            #endregion

            #region BasketItem
            CreateMap<BasketItem, BasketItemDTO>().ReverseMap();
            CreateMap<BasketItem, BasketItemCreateDTO>().ReverseMap();
            CreateMap<BasketItem, BasketItemUpdateDTO>().ReverseMap();
            #endregion

            #region UserFav
            CreateMap<UserFav, UserFavDTO>().ReverseMap();
            CreateMap<UserFav, UserFavCreateDTO>().ReverseMap();
            #endregion

            #region ApplicationUser
            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();

            #endregion


            #region ContactMessage
            CreateMap<ContactMessage, ContactMessageDTO>().ReverseMap();
            CreateMap<ContactMessage, ContactMessageCreateDTO>().ReverseMap();
            #endregion

            CreateMap<Invoice, InvoiceCreateDTO>().ReverseMap();
            CreateMap<Invoice, InvoiceDTO>().ReverseMap();


            #region Review

            CreateMap<Review, ReviewCreateDTO>().ReverseMap();
            CreateMap<Review, ReviewUptadeDTO>().ReverseMap();
          
            CreateMap<Review, ReviewDTO>()
    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.OrderItem.Product.Id))
    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.OrderItem.Product.Name)).ReverseMap();


            #endregion






        }
    }
}