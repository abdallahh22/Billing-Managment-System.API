using Invoice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Repositories.Interfaces
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
        Task<string> GetCompanyNameByIdAsync(int? companyId);
    }
}
