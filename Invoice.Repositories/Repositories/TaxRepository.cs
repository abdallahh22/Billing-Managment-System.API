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
    public class TaxRepository : GenericRepository<Tax>, ITaxRepository
    {
        public TaxRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Tax?> GetTaxByInvoiceAsync(int invoiceId)
        {
            return await _context.Taxes
                .FirstOrDefaultAsync(t => t.InvoiceID == invoiceId);
        }
    }
}
