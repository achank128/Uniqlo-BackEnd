using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.RegionService;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet("provinces/all")]
        public async Task<IActionResult> GetAllProvinces()
        {
            var response = await _regionService.GetAllProvinces();
            return Ok(response);
        }

        [HttpGet("districts/all")]
        public async Task<IActionResult> GetAllDistricts()
        {
            var response = await _regionService.GetAllDistricts();
            return Ok(response);
        }

        [HttpGet("wards/all")]
        public async Task<IActionResult> GetAllWards()
        {
            var response = await _regionService.GetAllWards();
            return Ok(response);
        }

        [HttpGet("districts")]
        public async Task<IActionResult> GetDistrictsByProvice(string provinceCode)
        {
            var response = await _regionService.GetDistrictsByProvice(provinceCode);
            return Ok(response);
        }

        [HttpGet("wards")]
        public async Task<IActionResult> GetWardsByDistrict(string districtCode)
        {
            var response = await _regionService.GetWardsByDistrict(districtCode);
            return Ok(response);
        }
    }
}
