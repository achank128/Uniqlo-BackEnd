using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Uniqlo.BusinessLogic.Services.Shared.ClaimService;
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
        private readonly IClaimService _claimService;


        public WishListsController(IWishListService wishListService, IClaimService claimService)
        {
            _wishListService = wishListService;
            _claimService = claimService;
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
            var response = await _wishListService.GetUserWishList(_claimService.GetUserId());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWishListRequest request)
        {
            var response = await _wishListService.Create(request);
            return Ok(response);
        }

        [HttpPost("add/{productId}")]
        [Authorize]
        public async Task<IActionResult> Create(Guid productId)
        {
            var response = await _wishListService.Create(new CreateWishListRequest
            {
                ProductId = productId,
                UserId = _claimService.GetUserId()
            });
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _wishListService.Delete(id);
            return Ok(response);
        }
    }
}
