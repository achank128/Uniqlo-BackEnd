using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.Attributes;
using Uniqlo.BusinessLogic.Services.CategoryService;
using Uniqlo.BusinessLogic.Shared.CacheService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Category;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ICacheService _cacheService;

        public CategoriesController(ICategoryService categoryService, ICacheService cacheService)
        {
            _categoryService = categoryService;
            _cacheService = cacheService;
        }

        [HttpGet]
        [Cache(120)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAll();
            return Ok(response);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter(FilterBaseRequest request)
        {
            var response = await _categoryService.Filter(request);
            return Ok(response);
        }

        [HttpGet("genderType/{id}")]
        [Cache(120)]
        public async Task<IActionResult> GetByGenderType(int id)
        {
            var response = await _categoryService.GetDisplayByGendeType(id);
            return Ok(response);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetByProduct(Guid id)
        {
            var response = await _categoryService.GetByProduct(id);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Cache(120)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _categoryService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequest request)
        {
            await _cacheService.RemoveByPrefixAsync("/api/categories");
            var response = await _categoryService.Create(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryRequest request)
        {
            await _cacheService.RemoveByPrefixAsync("/api/categories");
            var response = await _categoryService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _cacheService.RemoveByPrefixAsync("/api/categories");
            var response = await _categoryService.Delete(id);
            return Ok(response);
        }
    }
}
