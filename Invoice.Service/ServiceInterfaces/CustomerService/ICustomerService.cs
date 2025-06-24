using Invoice.Service.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.CustomerService
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByIdAsync(int? id);
        Task<IEnumerable<CustomerDto>> GetCustomersByCompanyAsync(int? companyId);
        Task<CustomerDto> UpdateCustomerAsync(CustomerDto customer);
        Task<CustomerDto> DeleteCustomerAsync(int? id);
        Task<CustomerDto> CreateCustomerAsync(CustomerDto customer);
        

    }
}
