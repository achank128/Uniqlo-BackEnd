﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.SizeService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Size;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _sizeService.GetAll();
            return Ok(response);
        }

        [HttpGet("genderType/{genderTypeId}")]
        public async Task<IActionResult> GetByGenderType(int genderTypeId)
        {
            var response = await _sizeService.GetByGenderType(genderTypeId);
            return Ok(response);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter(FilterBaseRequest request)
        {
            var response = await _sizeService.Filter(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _sizeService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSizeRequest request)
        {
            var response = await _sizeService.Create(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSizeRequest request)
        {
            var response = await _sizeService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _sizeService.Delete(id);
            return Ok(response);
        }
    }
}
