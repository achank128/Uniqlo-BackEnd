using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.ShipmentService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Shipment;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentsController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _shipmentService.GetAll();
            return Ok(response);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter(FilterShipmentRequest request)
        {
            var response = await _shipmentService.Filter(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _shipmentService.GetById(id);
            return Ok(response);
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrder(Guid orderId)
        {
            var response = await _shipmentService.GetByOrder(orderId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateShipmentRequest request)
        {
            var response = await _shipmentService.Create(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateShipmentRequest request)
        {
            var response = await _shipmentService.Update(request);
            return Ok(response);
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus(UpdateShipmentStatusRequest request)
        {
            var response = await _shipmentService.UpdateStatus(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _shipmentService.Delete(id);
            return Ok(response);
        }
    }
}
