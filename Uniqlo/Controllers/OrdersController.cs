using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.OrderService;
using Uniqlo.Models.Models;
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

        [HttpPost("all")]
        public async Task<IActionResult> GetAll(FilterBaseRequest request)
        {
            var response = await _orderService.GetAll(request);
            return Ok(response);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            var response = await _orderService.GetOrderDetails(id);
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

        [HttpPost("cretefull")]
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

        [HttpPut("cancel")]
        public async Task<IActionResult> CancelOrder(CancelOrderRequest request)
        {
            var response = await _orderService.Cancel(request);
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
