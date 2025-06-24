using Invoice.Service.DTO_s;
using Invoice.Service.ServiceInterfaces.DiscountService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDiscounts()
        => Ok(await _discountService.GetAllAsync());


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetDiscountById(int id)
           => Ok(await _discountService.GetByIdAsync(id));


        [HttpPost("Create")]
        public async Task<IActionResult> CreateDiscount([FromBody] DiscountDto discountDto)
          => Ok(await _discountService.CreateAsync(discountDto));


        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDiscount(int? id, [FromBody] DiscountDto discountDto)
         => Ok(await _discountService.UpdateAsync(discountDto));

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteDiscount(int? id)
         => Ok(_discountService.DeleteAsync(id));
    }
}
