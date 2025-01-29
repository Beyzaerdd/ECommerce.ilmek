using ECommerce.Shared.DTOs.ResponseDTOs;
using ECommerce.Shared.DTOs.UserFavDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IUserFavService
    {
        Task<ResponseDTO<NoContent>> AddToFavoritesAsync(UserFavCreateDTO userFavCreateDTO);
        Task<ResponseDTO<IEnumerable<UserFavDTO>>> GetUserFavoritesAsync(string applicationUserId);
     
        Task<ResponseDTO<int>> GetFavoriteCountAsync(string applicationUserId);
    }
}
