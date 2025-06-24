using Invoice.Repositories.Pagenations;
using Invoice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Repositories.Interfaces
{
      public interface IInvoicesRepository : IGenericRepository<Invoice.Data.Entities.Invoice>
      {
        Task<Invoice.Data.Entities.Invoice> GetInvoiceWithDetailsAsync(int id);
        Task<IEnumerable<Invoice.Data.Entities.Invoice>> GetInvoiceOfLastMonthAsync();
        Task<IEnumerable<Invoice.Data.Entities.Invoice>> GetInvoiceOfLastYearAsync();
        Task<Pagenate<Invoice.Data.Entities.Invoice>> GetPaginatedInvoicesAsync(int pageNumber, int pageSize, string? sortBy, bool ascending = true);
      }
}
