using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.CategoryService;
using Uniqlo.BusinessLogic.Services.ProductImageService;
using Uniqlo.BusinessLogic.Services.Shared.FileUploadService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Category;
using Uniqlo.Models.RequestModels.ProductImage;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductImagesController(
            IProductImageService productImageService,
            IWebHostEnvironment webHostEnvironment,
            IFileUploadService fileUploadService)
        {
            _productImageService = productImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productImageService.GetAll();
            return Ok(response);
        }

        [HttpPost("all")]
        public async Task<IActionResult> Filter(FilterBaseRequest request)
        {
            var response = await _productImageService.Filter(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _productImageService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductImageRequest request)
        {
            var response = await _productImageService.Create(request);
            return Ok(response);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(UploadProductImageRequest request)
        {
            var response = await _productImageService.Uploads(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductImageRequest request)
        {
            var response = await _productImageService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _productImageService.Delete(id);
            return Ok(response);
        }
    }
}
