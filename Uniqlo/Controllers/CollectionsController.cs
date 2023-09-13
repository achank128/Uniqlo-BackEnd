using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.CollectionService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Collection;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly ICollectionService _collectionService;

        public CollectionsController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _collectionService.GetAll();
            return Ok(response);
        }

        [HttpGet("show")]
        public async Task<IActionResult> GetShow()
        {
            var response = await _collectionService.GetDisplayShow();
            return Ok(response);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter(FilterBaseRequest request)
        {
            var response = await _collectionService.Filter(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _collectionService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCollectionRequest request)
        {
            var response = await _collectionService.Create(request);
            return Ok(response);
        }

        [HttpPost("createfull")]
        public async Task<IActionResult> CreateFull(CreateCollectionFullRequest request)
        {
            var response = await _collectionService.CreateFull(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCollectionRequest request)
        {
            var response = await _collectionService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _collectionService.Delete(id);
            return Ok(response);
        }
    }
}
