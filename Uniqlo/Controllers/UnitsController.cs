using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.Interfaces;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Unit;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitsService _unitsService;

        public UnitsController(IUnitsService unitService)
        {
            _unitsService = unitService;
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetAll(FilterBaseRequest request)
        {
            var response = await _unitsService.GetAll(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _unitsService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUnitRequest request)
        {
            var response = await _unitsService.Create(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUnitRequest request)
        {
            var response = await _unitsService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _unitsService.Delete(id);
            return Ok(response);
        }
    }
}
