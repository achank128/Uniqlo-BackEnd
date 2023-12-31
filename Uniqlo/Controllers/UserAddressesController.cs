﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.UserAddressService;
using Uniqlo.BusinessLogic.Shared.ClaimService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.UserAddress;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressesController : ControllerBase
    {
        private readonly IUserAddressService _userAddressService;
        private readonly IClaimService _claimService;

        public UserAddressesController(IUserAddressService userAddressService, IClaimService claimService)
        {
            _userAddressService = userAddressService;
            _claimService = claimService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userAddressService.GetAll();
            return Ok(response);
        }

        [HttpGet("myaddress")]
        [Authorize]
        public async Task<IActionResult> GetMyAddress()
        {
            var response = await _userAddressService.GetByUser(_claimService.GetUserId());
            return Ok(response);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter(FilterBaseRequest request)
        {
            var response = await _userAddressService.Filter(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _userAddressService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserAddressRequest request)
        {
            var response = await _userAddressService.Create(request);
            return Ok(response);
        }

        [HttpPut("setdefault/{id}")]
        [Authorize]
        public async Task<IActionResult> SetDefautl(Guid id)
        {
            var response = await _userAddressService.SetDefault(id, _claimService.GetUserId());
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserAddressRequest request)
        {
            var response = await _userAddressService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _userAddressService.Delete(id);
            return Ok(response);
        }
    }
}
