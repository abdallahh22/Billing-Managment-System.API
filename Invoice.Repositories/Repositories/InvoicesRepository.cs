using Invoice.Data.Context;
using Invoice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Invoice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoice.Repositories.Pagenations;

namespace Invoice.Repositories.Repositories
{
    public class InvoicesRepository : GenericRepository<Invoice.Data.Entities.Invoice>, IInvoicesRepository
    {
        public InvoicesRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Invoice.Data.Entities.Invoice?> GetInvoiceWithDetailsAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.InvoiceItems)
                .Include(i => i.Discount)
                .Include(i => i.Tax)
                .FirstOrDefaultAsync(i => i.Id == id);
        }
        // Get invoice at last Month
        public async Task<IEnumerable<Invoice.Data.Entities.Invoice>> GetInvoiceOfLastMonthAsync()
        {
            return await _context.Invoices
                                 .Include(C => C.Customer)
                                 .Where(c => c.CreatedAt >= DateTime.Now.AddYears(-1))
                                 .ToListAsync();
        }
        // Get invoice at last year
        public async Task<IEnumerable<Invoice.Data.Entities.Invoice>> GetInvoiceOfLastYearAsync()
        {
            return await _context.Invoices
                                 .Include(C => C.Customer)
                                 .Where(c => c.CreatedAt >= DateTime.Now.AddYears(-1))
                                 .ToListAsync();
        }

        // Use paginations and sorting
        public async Task<Pagenate<Invoice.Data.Entities.Invoice>> GetPaginatedInvoicesAsync(int pageNumber, int pageSize, string? sortBy, bool ascending = true)
        {
            var query = _context.Invoices.AsQueryable();

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (ascending)
                    query = query.OrderBy(s => EF.Property<object>(s, sortBy));
                else
                    query = query.OrderByDescending(s => EF.Property<object>(s, sortBy));
            }

            var totalItems = await query.CountAsync();

            var items = await query.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            return new Pagenate<Invoice.Data.Entities.Invoice>
            {
                TotalItems = totalItems,
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
        

        
      
    }
}

