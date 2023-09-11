using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Uniqlo.BusinessLogic.Services.OrderService;
using Uniqlo.Models.RequestModels;
using Uniqlo.Models.RequestModels.Order;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _orderService.GetAll();
            return Ok(response);
        }

        [HttpPost("all")]
        public async Task<IActionResult> Filter(FilterOrderRequest request)
        {
            var response = await _orderService.Filter(request);
            return Ok(response);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            var response = await _orderService.GetOrderDetails(id);
            return Ok(response);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrderByUser(Guid userId)
        {
            var response = await _orderService.GetOrderByUser(userId);
            return Ok(response);
        }

        [HttpGet("myorders")]
        [Authorize]
        public async Task<IActionResult> GetMyOrders()
        {
            Guid userId = new Guid(User.FindFirstValue(ClaimTypes.Sid));
            var response = await _orderService.GetOrderByUser(userId);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var response = await _orderService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            var response = await _orderService.Create(request);
            return Ok(response);
        }

        [HttpPost("createfull")]
        public async Task<IActionResult> CreateFull(CreateOrderFullRequest request)
        {
            var response = await _orderService.CreateFull(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderRequest request)
        {
            var response = await _orderService.Update(request);
            return Ok(response);
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus(UpdateOrderStatusRequest request)
        {
            var response = await _orderService.UpdateStatus(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, DeleteRequest request)
        {
            var response = await _orderService.Delete(id, request);
            return Ok(response);
        }
       
    }
}
