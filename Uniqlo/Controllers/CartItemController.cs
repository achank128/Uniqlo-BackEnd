using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.CartItemService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.CartItem;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetAll(FilterBaseRequest request)
        {
            var response = await _cartItemService.GetAll(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _cartItemService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCartItemRequest request)
        {
            var response = await _cartItemService.Create(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCartItemRequest request)
        {
            var response = await _cartItemService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _cartItemService.Delete(id);
            return Ok(response);
        }
    }
}
