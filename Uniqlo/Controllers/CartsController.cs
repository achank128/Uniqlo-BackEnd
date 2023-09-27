using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.Attributes;
using Uniqlo.BusinessLogic.Services.CartService;
using Uniqlo.BusinessLogic.Shared.ClaimService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels;
using Uniqlo.Models.RequestModels.Cart;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IClaimService _claimService;

        public CartsController(ICartService cartService, IClaimService claimService)
        {
            _cartService = cartService;
            _claimService = claimService;
        }

        /// <summary>
        /// Lấy tất cả giỏ hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Cache(120)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _cartService.GetAll();
            return Ok(response);
        }

        /// <summary>
        /// Lọc giỏ hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public async Task<IActionResult> Filter(FilterBaseRequest request)
        {
            var response = await _cartService.Filter(request);
            return Ok(response);
        }

        /// <summary>
        /// Lấy 1 giỏ hàng theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _cartService.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Lấy giỏ hàng theo user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCartByUser(Guid userId)
        {
            var response = await _cartService.GetByUser(userId);
            return Ok(response);
        }

        /// <summary>
        /// Lấy giỏi hàng của tôi
        /// </summary>
        /// <returns></returns>
        [HttpGet("mycart")]
        [Authorize]
        public async Task<IActionResult> GetMyCart()
        {
            var response = await _cartService.GetByUser(_claimService.GetUserId());
            return Ok(response);
        }

        /// <summary>
        /// Tạo giỏ hàng
        /// </summary>
        /// <param name="request">CreateCartRequest</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCartRequest request)
        {
            var response = await _cartService.Create(request);
            return Ok(response);
        }

        /// <summary>
        /// Sửa giỏ hàng
        /// </summary>
        /// <param name="request">UpdateCartRequest</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCartRequest request)
        {
            var response = await _cartService.Update(request);
            return Ok(response);
        }

        /// <summary>
        /// Clear giỏ hàng, xóa hết item
        /// </summary>
        /// <param name="request">UpdateCartRequest</param>
        /// <returns></returns>
        [HttpPut("clear/{id}")]
        public async Task<IActionResult> Clear(Guid id)
        {
            var response = await _cartService.ClearItem(id);
            return Ok(response);
        }

        /// <summary>
        /// Xóa giỏ hàng
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="request">DeleteRequest</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, DeleteRequest request)
        {
            var response = await _cartService.Delete(id, request);
            return Ok(response);
        }
    }
}
