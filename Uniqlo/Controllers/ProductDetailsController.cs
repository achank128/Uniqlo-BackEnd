using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.ProductDetailService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.ProductDetail;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productDetailService.GetAll();
            return Ok(response);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(Guid productId)
        {
            var response = await _productDetailService.GetByProduct(productId);
            return Ok(response);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter(FilterProductDetailRequest request)
        {
            var response = await _productDetailService.Filter(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _productDetailService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDetailRequest request)
        {
            var response = await _productDetailService.Create(request);
            return Ok(response);
        }

        [HttpPost("product/{productId}")]
        public async Task<IActionResult> CreateForProduct(Guid productId)
        {
            var response = await _productDetailService.CreateForProduct(productId);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDetailRequest request)
        {
            var response = await _productDetailService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _productDetailService.Delete(id);
            return Ok(response);
        }
    }
}
