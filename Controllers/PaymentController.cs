using Invoice.Service.DTO_s;
using Invoice.Service.ServiceInterfaces.PaymentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] PaymentDto paymentDto)
         => Ok(await _paymentService.CreateAsync(paymentDto));

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
          => Ok(await _paymentService.GetAllAsync());

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
          => Ok(await _paymentService.GetByIdAsync(id));

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(int? id, [FromBody] PaymentDto paymentDto)
          => Ok(await _paymentService.UpdateAsync(paymentDto));

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _paymentService.DeleteAsync(id));
    }
}
