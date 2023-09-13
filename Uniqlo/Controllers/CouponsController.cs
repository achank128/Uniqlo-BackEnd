using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Uniqlo.BusinessLogic.Services.CouponService;
using Uniqlo.BusinessLogic.Services.Shared.ClaimService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Coupon;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;
        private readonly IClaimService _claimService;

        public CouponsController(ICouponService couponService, IClaimService claimService)
        {
            _couponService = couponService;
            _claimService = claimService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _couponService.GetAll();
            return Ok(response);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter(FilterBaseRequest request)
        {
            var response = await _couponService.Filter(request);
            return Ok(response);
        }

        [HttpGet("mycoupon")]
        [Authorize]
        public async Task<IActionResult> GetMyCoupon()
        {
            var response = await _couponService.GetByUser(_claimService.GetUserId());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _couponService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponRequest request)
        {
            var response = await _couponService.Create(request);
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
    }
}
