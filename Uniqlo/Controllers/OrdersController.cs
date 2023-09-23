using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Uniqlo.Attributes;
using Uniqlo.BusinessLogic.Services.OrderService;
using Uniqlo.BusinessLogic.Shared.CacheService;
using Uniqlo.Models.RequestModels;
using Uniqlo.Models.RequestModels.Order;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICacheService _cacheService;

        public OrdersController(IOrderService orderService, ICacheService cacheService)
        {
            _orderService = orderService;
            _cacheService = cacheService;
        }

        /// <summary>
        /// Lấy tất cả đơn hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Cache(120)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _orderService.GetAll();
            return Ok(response);
        }

        /// <summary>
        /// Lọc đơn hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("filter")]
        public async Task<IActionResult> Filter(FilterOrderRequest request)
        {
            var response = await _orderService.Filter(request);
            return Ok(response);
        }

        /// <summary>
        /// Lấy đơn hàng theo người dùng
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("user/{userId}")]
        [Cache(120)]
        public async Task<IActionResult> GetOrderByUser(Guid userId)
        {
            var response = await _orderService.GetOrderByUser(userId);
            return Ok(response);
        }

        /// <summary>
        /// Lấy đơn hàng tài khoản
        /// </summary>
        /// <returns></returns>
        [HttpGet("myorders")]
        [Authorize]
        public async Task<IActionResult> GetMyOrders()
        {
            Guid userId = new Guid(User.FindFirstValue(ClaimTypes.Sid));
            var response = await _orderService.GetOrderByUser(userId);
            return Ok(response);
        }

        /// <summary>
        /// Lấy đơn hàng theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Cache(120)]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var response = await _orderService.GetById(id);
            return Ok(response);
        }

        /// <summary>
        /// Thêm mới đơn hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            await _cacheService.RemoveByPrefixAsync("/api/orders");
            var response = await _orderService.Create(request);
            return Ok(response);
        }

        /// <summary>
        /// Thêm đơn hàng đầy đủ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createfull")]
        public async Task<IActionResult> CreateFull(CreateOrderFullRequest request)
        {
            await _cacheService.RemoveByPrefixAsync("/api/orders");
            var response = await _orderService.CreateFull(request);
            return Ok(response);
        }

        /// <summary>
        /// Cập nhật đơn hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderRequest request)
        {
            await _cacheService.RemoveByPrefixAsync("/api/orders");
            var response = await _orderService.Update(request);
            return Ok(response);
        }

        /// <summary>
        /// Cập nhật trạng thái đơn hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus(UpdateOrderStatusRequest request)
        {
            await _cacheService.RemoveByPrefixAsync("/api/orders");
            var response = await _orderService.UpdateStatus(request);
            return Ok(response);
        }

        /// <summary>
        /// Xóa đơn hàng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, DeleteRequest request)
        {
            await _cacheService.RemoveByPrefixAsync("/api/orders");
            var response = await _orderService.Delete(id, request);
            return Ok(response);
        }
       
    }
}
