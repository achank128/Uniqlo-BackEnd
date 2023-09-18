using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Uniqlo.BusinessLogic.Services.UserCouponService;
using Uniqlo.BusinessLogic.Shared.ClaimService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Coupon;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCouponsController : ControllerBase
    {
        private readonly IUserCouponService _userCouponService;
        private readonly IClaimService _claimService;

        public UserCouponsController(IUserCouponService userCouponService, IClaimService claimService)
        {
            _userCouponService = userCouponService;
            _claimService = claimService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userCouponService.GetAll();
            return Ok(response);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter(FilterBaseRequest request)
        {
            var response = await _userCouponService.Filter(request);
            return Ok(response);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserCoupons(Guid userId)
        {
            var response = await _userCouponService.GetUserCoupons(userId);
            return Ok(response);
        }

        [HttpGet("mycoupon")]
        [Authorize]
        public async Task<IActionResult> GetMyCoupons()
        {
            var response = await _userCouponService.GetUserCoupons(_claimService.GetUserId());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserCoupon(CreateUserCouponRequest request)
        {
            var response = await _userCouponService.CreateUserCoupon(request);
            return Ok(response);
        }

        [HttpPost("add/{couponCode}")]
        public async Task<IActionResult> AddUserCoupon(string couponCode)
        {
            var response = await _userCouponService.AddUserCoupon(_claimService.GetUserId(), couponCode);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCoupon(Guid id)
        {
            var response = await _userCouponService.DeleteUserCoupon(id);
            return Ok(response);
        }
    }
}
