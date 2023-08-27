using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.Interfaces;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Collection;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly ICollectionsService _collectionsService;

        public CollectionsController(ICollectionsService collectionsService)
        {
            _collectionsService = collectionsService;
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetAll(FilterBaseRequest request)
        {
            var response = await _collectionsService.GetAll(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _collectionsService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCollectionRequest request)
        {
            var response = await _collectionsService.Create(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCollectionRequest request)
        {
            var response = await _collectionsService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _collectionsService.Delete(id);
            return Ok(response);
        }
    }
}
