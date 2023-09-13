using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.PaymentService;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Payment;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _paymentService.GetAll();
            return Ok(response);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> Filter(FilterBaseRequest request)
        {
            var response = await _paymentService.Filter(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _paymentService.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentRequest request)
        {
            var response = await _paymentService.Create(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePaymentRequest request)
        {
            var response = await _paymentService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _paymentService.Delete(id);
            return Ok(response);
        }
    }
}
