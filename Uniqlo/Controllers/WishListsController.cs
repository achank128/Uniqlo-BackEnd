using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Uniqlo.BusinessLogic.Services.UserService;
using Uniqlo.BusinessLogic.Services.WishListService;
using Uniqlo.Models.Models;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListsController : ControllerBase
    {
        private readonly IWishListService _wishListService;

        public WishListsController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetAll(FilterBaseRequest request)
        {
            var response = await _wishListService.GetAll(request);
            return Ok(response);
        }

        [HttpGet("mywishlist")]
        [Authorize]
        public async Task<IActionResult> GetMyWishList()
        {
            Guid userId = new Guid(User.FindFirstValue(ClaimTypes.Sid));
            var response = await _wishListService.GetUserWishList(userId);
            return Ok(response);
        }

        [HttpPost("wishlist/{productId}")]
        [Authorize]
        public async Task<IActionResult> GetMyWishList(Guid productId)
        {
            Guid userId = new Guid(User.FindFirstValue(ClaimTypes.Sid));
            var response = await _wishListService.AddWishList(userId, productId);
            return Ok(response);
        }
    }
}
