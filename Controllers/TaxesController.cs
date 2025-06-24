using Invoice.Service.DTO_s;
using Invoice.Service.ServiceInterfaces.TaxService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxesController : ControllerBase
    {
        private readonly ITaxesService _taxService;

        public TaxesController(ITaxesService taxService)
        {
            _taxService = taxService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] TaxDto taxDto)
         => Ok(await _taxService.CreateAsync(taxDto));

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
         => Ok(await _taxService.GetAllAsync());

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        => Ok(await _taxService.GetByIdAsync(id));

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(int? id, [FromBody] TaxDto taxDto)
         => Ok(await _taxService.UpdateAsync(taxDto));

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        => Ok(await _taxService.DeleteAsync(id));
    }
}
