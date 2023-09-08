using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.CollectionPostService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.CollectionPost;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionPostsController : ControllerBase
    {
        private readonly ICollectionPostService _collectionPostService;

        public CollectionPostsController(ICollectionPostService collectionPostService)
        {
            _collectionPostService = collectionPostService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _collectionPostService.GetAll();
            return Ok(response);
        }

        [HttpPost("all")]
        public async Task<IActionResult> Filter(FilterBaseRequest request)
        {
            var response = await _collectionPostService.Filter(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _collectionPostService.GetById(id);
            return Ok(response);
        }

        [HttpGet("collection/{id}")]
        public async Task<IActionResult> GetByCollection(Guid id)
        {
            var response = await _collectionPostService.GetByCollection(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCollectionPostRequest request)
        {
            var response = await _collectionPostService.Create(request);
            return Ok(response);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(UploadCollectionPostRequest request)
        {
            var response = await _collectionPostService.Upload(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCollectionPostRequest request)
        {
            var response = await _collectionPostService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _collectionPostService.Delete(id);
            return Ok(response);
        }
    }
}
