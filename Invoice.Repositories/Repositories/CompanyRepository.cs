using Invoice.Data.Context;
using Invoice.Data.Entities;
using Invoice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Repositories.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<string> GetCompanyNameByIdAsync(int? companyId)
        {
            var companyName = await _context.Companies
                                            .Where(c => c.Id == companyId)
                                            .Select(c => c.CompanyName)
                                            .FirstOrDefaultAsync();
            return companyName ?? throw new Exception("Company not found");
        }
    }
}
