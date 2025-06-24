using Invoice.Service.DTO_s;
using Invoice.Service.HanddleResponses;
using Invoice.Service.ServiceInterfaces.CompanyService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCompanies()
          => Ok(await _companyService.GetAll());



        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetCompanyById(int? id)
           => Ok(await _companyService.GetById(id));



        [HttpGet("GetByName/{companyId}")]
        public async Task<IActionResult> GetCompanyName(int? companyId)
          => Ok(await _companyService.GetByName(companyId));



        [HttpPost("Create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDto companyDto)
            => Ok(await _companyService.CreateAsync(companyDto));


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] CompanyDto companyDto)
          => Ok(await _companyService.UpdateCompanyAsync(companyDto));


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCompany(int? id)
             => Ok(await _companyService.DeleteCompanyAsync(id));
    }
}
