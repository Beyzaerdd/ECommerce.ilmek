using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.BasketDTOs;
using ECommerce.Shared.DTOs.ProductDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.UserFavDTOs;
using ECommerce.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete
{
    public class UserFavService : IUserFavService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserFavService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseDTO<NoContent>> AddToFavoritesAsync(UserFavCreateDTO userFavCreateDTO)
        {
            var userId = httpContextAccessor.GetUserId();

            var favorite = await unitOfWork.GetRepository<UserFav>()
                .GetAsync(x => x.ApplicationUserId == userId && x.ProductId == userFavCreateDTO.ProductId);

            if (favorite != null)
            {
                if (!favorite.IsDeleted)
                {
                    // Ürün zaten aktif olarak favorilerde mevcut
                    return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
            {
                new ErrorDetail { Message = "Product is already in favorites.", Code = "FAVORITE_EXISTS", Target = "UserFavorite" }
            }, HttpStatusCode.BadRequest);
                }
                else
                {
                    // Ürün favorilerde bulunuyor ama IsDeleted true, yani daha önce kaldırılmış.
                    // Tekrar aktif hale getir.
                    favorite.IsDeleted = false;
                    await unitOfWork.SaveChangesAsync();
                    return ResponseDTO<NoContent>.Success(HttpStatusCode.OK);
                }
            }

            // Favorilerde hiç kayıt bulunamadıysa yeni bir kayıt oluştur.
            var userFavorite = mapper.Map<UserFavCreateDTO, UserFav>(userFavCreateDTO);
            userFavorite.ApplicationUserId = userId;
            userFavorite.IsDeleted = false;  // Yeni eklenen kayıt aktif olarak oluşturulmalı.

            await unitOfWork.GetRepository<UserFav>().AddAsync(userFavorite);
            await unitOfWork.SaveChangesAsync();

            return ResponseDTO<NoContent>.Success(HttpStatusCode.Created);
        }


        public async Task<ResponseDTO<int>> GetFavoriteCountAsync(string applicationUserId)
        {
           var favoriteCount = await unitOfWork.GetRepository<UserFav>().CountAsync(x => x.ApplicationUserId == applicationUserId);
            if (favoriteCount == 0)
            {
                return ResponseDTO<int>.Fail(new List<ErrorDetail>
            {
                new ErrorDetail { Message = "There is no favorite product.", Code = "FAVORITE_NOT_FOUND", Target = "UserFavorite" }
            }, HttpStatusCode.NotFound);
            }

           
            return ResponseDTO<int>.Success(favoriteCount, HttpStatusCode.OK);


        }
        public async Task<ResponseDTO<NoContent>> RemoveFromFavoritesAsync(int favId)
        {
            var applicationUserId = httpContextAccessor.GetUserId();

            var favorite = await unitOfWork.GetRepository<UserFav>()
                .GetAsync(x => x.Id == favId && x.ApplicationUserId == applicationUserId);

            if (favorite == null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail { Message = "Favorite product not found.", Code = "FAVORITE_NOT_FOUND", Target = "UserFavorite" }
        }, HttpStatusCode.NotFound);
            }

            favorite.IsDeleted = true;  // IsDeleted alanını true yap
            await unitOfWork.SaveChangesAsync();
       

            return ResponseDTO<NoContent>.Success(HttpStatusCode.OK);
        }

        public async Task<ResponseDTO<IEnumerable<UserFavDTO>>> GetUserFavoritesAsync(int? take = null)
        {
            var applicationUserId = httpContextAccessor.GetUserId();

           
            var favorites = await unitOfWork.GetRepository<UserFav>()
                .GetAllAsync(
                  x => x.ApplicationUserId == applicationUserId && x.IsDeleted == false, orderBy: query => query.OrderByDescending(x => x.CreatedAt),
                take: take,false,
                    q => q.Include(y => y.Product)  
                );

     
            if (favorites == null || !favorites.Any())
            {
                return ResponseDTO<IEnumerable<UserFavDTO>>.Fail(new List<ErrorDetail>
        {
            new ErrorDetail { Message = "There is no favorite product.", Code = "FAVORITE_NOT_FOUND", Target = "UserFavorite" }
        }, HttpStatusCode.NotFound);
            }

           
            var favoritesDTO = mapper.Map<IEnumerable<UserFavDTO>>(favorites);

            return ResponseDTO<IEnumerable<UserFavDTO>>.Success(favoritesDTO, HttpStatusCode.OK);
        }



    }
}
