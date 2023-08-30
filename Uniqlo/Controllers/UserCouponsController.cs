using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Uniqlo.BusinessLogic.Services.UserCouponService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Coupon;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCouponsController : ControllerBase
    {
        private readonly IUserCouponService _userCouponService;

        public UserCouponsController(IUserCouponService userCouponService)
        {
            _userCouponService = userCouponService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userCouponService.GetAll();
            return Ok(response);
        }

        [HttpPost("all")]
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

        [HttpGet("mycoupons")]
        public async Task<IActionResult> GetMyCoupons()
        {
            Guid userId = new Guid(User.FindFirstValue(ClaimTypes.Sid));
            var response = await _userCouponService.GetUserCoupons(userId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserCoupon(CreateUserCouponRequest request)
        {
            var response = await _userCouponService.CreateUserCoupon(request);
            return Ok(response);
        }

        [HttpPost("user/{couponId}")]
        public async Task<IActionResult> AddUserCoupon(Guid couponId)
        {
            Guid userId = new Guid(User.FindFirstValue(ClaimTypes.Sid));
            var response = await _userCouponService.AddUserCoupon(userId, couponId);
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
