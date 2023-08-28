using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Uniqlo.BusinessLogic.Services.CouponService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Coupon;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponsController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetAll(FilterBaseRequest request)
        {
            var response = await _couponService.GetAll(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _couponService.GetById(id);
            return Ok(response);
        }

        [HttpGet("usercoupon/{userId}")]
        public async Task<IActionResult> GetUserCoupons(Guid userId)
        {
            var response = await _couponService.GetUserCoupons(userId);
            return Ok(response);
        }

        [HttpGet("mycoupons")]
        public async Task<IActionResult> GetMyCoupons()
        {
            Guid userId = new Guid(User.FindFirstValue(ClaimTypes.Sid));
            var response = await _couponService.GetUserCoupons(userId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponRequest request)
        {
            var response = await _couponService.Create(request);
            return Ok(response);
        }

        [HttpPost("usercoupon")]
        public async Task<IActionResult> CreateUserCoupon(CreateUserCouponRequest request)
        {
            var response = await _couponService.CreateUserCoupon(request);
            return Ok(response);
        }

        [HttpPost("usercoupon/{couponId}")]
        public async Task<IActionResult> AddUserCoupon(Guid couponId)
        {
            Guid userId = new Guid(User.FindFirstValue(ClaimTypes.Sid));
            var response = await _couponService.AddUserCoupon(userId, couponId);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCouponRequest request)
        {
            var response = await _couponService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _couponService.Delete(id);
            return Ok(response);
        }

        [HttpDelete("usercoupon/{id}")]
        public async Task<IActionResult> DeleteUserCoupon(Guid id)
        {
            var response = await _couponService.DeleteUserCoupon(id);
            return Ok(response);
        }
    }
}
