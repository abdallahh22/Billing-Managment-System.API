using Invoice.Service.DTO_s;
using Invoice.Service.ServiceInterfaces.InvoiceItemService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemsController : ControllerBase
    {
        private readonly IInvoiceItemService _invoiceItemService;

        public InvoiceItemsController(IInvoiceItemService invoiceItemService)
        {
            _invoiceItemService = invoiceItemService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllInvoiceItems()
          => Ok(await _invoiceItemService.GetAllAsync());

        [HttpGet("GetById")]
        public async Task<IActionResult> GetInvoiceItemById(int id)
         => Ok(await _invoiceItemService.GetByIdAsync(id));

        [HttpPost("Create")]
        public async Task<IActionResult> CreateInvoiceItem([FromBody] InvoiceItemDto invoiceItemDto)
         => Ok(await _invoiceItemService.CreateAsync(invoiceItemDto));

        [HttpPut("UpdateInvoiceItem")]
        public async Task<IActionResult> UpdateInvoiceItem(int? id, [FromBody] InvoiceItemDto invoiceItemDto)
        => Ok(await _invoiceItemService.UpdateAsync(invoiceItemDto));

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteInvoiceItem(int id)
         => Ok(_invoiceItemService.DeleteAsync(id));
    }
}
