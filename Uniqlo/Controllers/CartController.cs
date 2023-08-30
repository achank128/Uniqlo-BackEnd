﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.CartService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels;
using Uniqlo.Models.RequestModels.Cart;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _cartService.GetAll();
            return Ok(response);
        }

        [HttpPost("all")]
        public async Task<IActionResult> Filter(FilterBaseRequest request)
        {
            var response = await _cartService.Filter(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _cartService.GetById(id);
            return Ok(response);
        }

        [HttpGet("mycart")]
        [Authorize]
        public async Task<IActionResult> GetMyCart()
        {
            var response = await _cartService.GetByUser();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCartRequest request)
        {
            var response = await _cartService.Create(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCartRequest request)
        {
            var response = await _cartService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, DeleteRequest request)
        {
            var response = await _cartService.Delete(id, request);
            return Ok(response);
        }
    }
}
