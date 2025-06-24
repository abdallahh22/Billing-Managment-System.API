using Invoice.Data.Entities;
using Invoice.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Repositories.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    Task<IEnumerable<Customer>> GetCustomersByCompanyAsync(int? id);
    }

}
