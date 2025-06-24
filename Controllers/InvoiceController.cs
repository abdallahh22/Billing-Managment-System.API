using Invoice.Service.DTO_s;
using Invoice.Service.ServiceInterfaces.InvoiceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost("CreateInvoice")]
        public async Task<IActionResult> CreateAsync([FromBody] InvoiceDto invoiceDto)
          => Ok(await _invoiceService.CreateAsync(invoiceDto));


        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
            => Ok(await _invoiceService.DeleteAsync(id));


        [HttpGet("GetAllInvoices")]
        public async Task<IActionResult> GetInvoicesAsync()
          => Ok(await _invoiceService.GetInvoicesAsync());


        [HttpGet("GetInvoiceById")]
        public async Task<IActionResult> GetByIdAsync(int id)
         => Ok(await _invoiceService.GetByIdAsync(id));


        [HttpGet("GetDetailsInvoice/{id}")]
        public async Task<IActionResult> GetInvoiceWithDetailsAsync(int id)
         => Ok(await _invoiceService.GetInvoiceWithDetailsAsync(id));


        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginatedInvoicesAsync([FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] string? sortBy, [FromQuery] bool ascending = true)
           => Ok(await _invoiceService.GetPaginatedInvoicesAsync(pageNumber, pageSize, sortBy, ascending));


        [HttpPut("UpdateInvoice")]
        public async Task<IActionResult> UpdateAsync(int? id, [FromBody] InvoiceDto invoiceDto)
          => Ok(await _invoiceService.UpdateAsync(invoiceDto));

    }

}
