﻿using ECommerce.Business.Abstract;
using ECommerce.Shared.DTOs.UserFavDTOs;
using ECommerce.Shared.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavsController : CustomControllerBase
    {
        private readonly IUserFavService _userFavService;

        public UserFavsController(IUserFavService userFavService)
        {
            _userFavService = userFavService;
        }

        [Authorize(Policy = "User")]
        [HttpPost("addToFavorite")]
        public async Task<IActionResult> AddToFavorites([FromBody] UserFavCreateDTO userFavCreateDTO)
        {
            var response = await _userFavService.AddToFavoritesAsync(userFavCreateDTO);
            return Ok(response);
        }
        [Authorize(Policy = "SellerAndAdmin")]
        [HttpGet("getFavoriteCount")]

        public async Task<IActionResult> GetFavoriteCount([FromQuery] string applicationUserId)
        {
            var response = await _userFavService.GetFavoriteCountAsync(applicationUserId);
            return Ok(response);
        }
        [Authorize(Policy = "User")]
        [HttpGet("getUserFav")]
        public async Task<IActionResult> GetUserFavorites()
        {
            var response = await _userFavService.GetUserFavoritesAsync();
            return Ok(response);
        }
        [HttpDelete("Remove")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> RemoveFromFavorites(int favId)
        {
            var response = await _userFavService.RemoveFromFavoritesAsync(favId);
            return Ok(response);
        }
    }
}
