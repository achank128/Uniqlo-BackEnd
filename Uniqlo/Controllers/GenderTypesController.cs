using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.GenderTypeService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.GenderType;
using Uniqlo.Models.RequestModels.Unit;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderTypesController : ControllerBase
    {
        private readonly IGenderTypeService _genderService;

        public GenderTypesController(IGenderTypeService genderService)
        {
            _genderService = genderService;
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetAll(FilterBaseRequest request)
        {
            var response = await _genderService.GetAll(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _genderService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGenderTypeRequest request)
        {
            var response = await _genderService.Create(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateGenderTypeRequest request)
        {
            var response = await _genderService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _genderService.Delete(id);
            return Ok(response);
        }
    }
}
