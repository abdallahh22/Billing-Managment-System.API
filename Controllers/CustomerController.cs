using Invoice.Service.DTO_s;
using Invoice.Service.ServiceInterfaces.CustomerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCustomersAsync()
          => Ok(await _customerService.GetAllAsync());


        [HttpGet("GetById")]
        public async Task<IActionResult> GetCustomersById(int id)
           => Ok(await _customerService.GetByIdAsync(id));


        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CustomerDto customerDto)
           => Ok(await _customerService.CreateCustomerAsync(customerDto));


        [HttpGet("GetCustomersByCompany")]
        public async Task<IActionResult> GetCustomersByCompanyAsync(int companyId)
          => Ok(await _customerService.GetCustomersByCompanyAsync(companyId));


        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        => Ok(await _customerService.UpdateCustomerAsync(customerDto));


        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
          => Ok(await _customerService.DeleteCustomerAsync(id));

        

    }
}
