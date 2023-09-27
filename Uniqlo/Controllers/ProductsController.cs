using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.ProductService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels;
using Uniqlo.Models.RequestModels.Product;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Lấy tất cả sản phẩm
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _productService.GetAll();
            return Ok(response);
        }

        /// <summary>
        /// Lọc sản phẩm
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public async Task<IActionResult> GetFilter(FilterProductRequest request)
        {
            var response = await _productService.Filter(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _productService.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Thêm sản phẩm
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var response = await _productService.Create(request);
            return Ok(response);
        }

        /// <summary>
        /// Thêm sản phẩm đầy đủ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateFull(CreateProductFullRequest request)
        {
            var response = await _productService.CreateFull(request);
            return Ok(response);
        }


        /// <summary>
        /// Thêm sản phẩm tự động
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createCrawl")]
        public async Task<IActionResult> CreateCrawl(CreateProductCrawlRequest request)
        {
            var response = await _productService.CreateCrawl(request);
            return Ok(response);
        }

        /// <summary>
        /// Cập nhật thông tin sản phẩm
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductRequest request)
        {
            var response = await _productService.Update(request);
            return Ok(response);
        }

        /// <summary>
        /// Cập nhật thông tin sản phẩm đầy đủ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateFull(UpdateProductFullRequest request)
        {
            var response = await _productService.UpdateFull(request);
            return Ok(response);
        }


        /// <summary>
        /// Xóa sản phẩm theo mã
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, DeleteRequest request)
        {
            var response = await _productService.Delete(id, request);
            return Ok(response);
        }

        private string GetInstanceId()
        {
            var instanceId = HttpContext.Session.GetString("InstanceId");
            if (string.IsNullOrEmpty(instanceId))
            {
                instanceId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("InstanceId", instanceId);
            }
            return instanceId;
        }
    }
}
