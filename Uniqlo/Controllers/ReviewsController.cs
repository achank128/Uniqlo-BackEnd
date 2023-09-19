using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.ReviewService;
using Uniqlo.BusinessLogic.Shared.ClaimService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Review;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IClaimService _claimService;

        public ReviewsController(IReviewService couponService, IClaimService claimService)
        {
            _reviewService = couponService;
            _claimService = claimService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _reviewService.GetAll();
            return Ok(response);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter(FilterReviewRequest request)
        {
            var response = await _reviewService.Filter(request);
            return Ok(response);
        }

        [HttpGet("myreview")]
        [Authorize]
        public async Task<IActionResult> GetMyCoupon()
        {
            var response = await _reviewService.GetByUser(_claimService.GetUserId());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _reviewService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewRequest request)
        {
            var response = await _reviewService.Create(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateReviewRequest request)
        {
            var response = await _reviewService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _reviewService.Delete(id);
            return Ok(response);
        }
    }
}
