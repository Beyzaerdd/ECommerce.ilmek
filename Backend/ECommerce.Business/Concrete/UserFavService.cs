using AutoMapper;
using ECommerce.Business.Abstract;
using ECommerce.Data.Abstract;
using ECommerce.Data.Concrete;
using ECommerce.Entity.Concrete;
using ECommerce.Shared.DTOs.BasketDTOs;
using ECommerce.Shared.DTOs.ProductDTOs;
using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.UserFavDTOs;
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

        public UserFavService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO<NoContent>> AddToFavoritesAsync(UserFavCreateDTO userFavCreateDTO)
        {
            var favorite = await unitOfWork.GetRepository<UserFav>().GetAsync(x => x.ApplicationUserId == userFavCreateDTO.ApplicationUserId && x.ProductId == userFavCreateDTO.ProductId);
            if (favorite != null)
            {
                return ResponseDTO<NoContent>.Fail(new List<ErrorDetail>
            {
                new ErrorDetail { Message = "Product is already in favorites.", Code = "FAVORITE_EXISTS", Target = "UserFavorite" }
            }, HttpStatusCode.BadRequest);
            }

           var userFavorite = mapper.Map<UserFavCreateDTO, UserFav>(userFavCreateDTO);
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

        public async Task<ResponseDTO<IEnumerable<UserFavDTO>>> GetUserFavoritesAsync(string applicationUserId)
        {
            var favorites = await unitOfWork.GetRepository<UserFav>()
                .GetAllAsync(
                    x => x.ApplicationUserId == applicationUserId, null,
                          null,
                          false,
                           query => query.Include(y => y.Product)


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
