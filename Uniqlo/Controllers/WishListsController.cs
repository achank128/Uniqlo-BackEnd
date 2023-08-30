using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Uniqlo.BusinessLogic.Services.UserService;
using Uniqlo.BusinessLogic.Services.WishListService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.WishList;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _wishListService.GetAll();
            return Ok(response);
        }

        [HttpPost("all")]
        public async Task<IActionResult> Filter(FilterBaseRequest request)
        {
            var response = await _wishListService.Filter(request);
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
        public async Task<IActionResult> GetMyWishList(CreateWishListRequest request)
        {
            var response = await _wishListService.Create(request);
            return Ok(response);
        }
    }
}
