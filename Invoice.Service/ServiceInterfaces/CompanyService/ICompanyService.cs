using Invoice.Service.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.CompanyService
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAll();
        Task<CompanyDto> GetById(int? id);
        Task<CompanyDto> GetByName(int? CompanyId);
        Task<CompanyDto> CreateAsync(CompanyDto companyDto);
        Task<CompanyDto> UpdateCompanyAsync(CompanyDto companyDto);
        Task<CompanyDto> DeleteCompanyAsync(int? id);
    


    }
}
