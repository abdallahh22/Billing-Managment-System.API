using Invoice.Repositories.Pagenations;
using Invoice.Service.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.InvoiceService
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> CreateAsync(InvoiceDto invoiceDto);
        Task<InvoiceDto> GetInvoiceWithDetailsAsync(int id);
        Task<IEnumerable<InvoiceDto>> GetInvoicesAsync();
        Task<InvoiceDto> UpdateAsync(InvoiceDto invoiceDto);
        Task<InvoiceDto> DeleteAsync(int id);
        Task<InvoiceDto> GetByIdAsync(int? id);
        Task<Pagenate<InvoiceDto>> GetPaginatedInvoicesAsync(int pageNumber, int pageSize, string? sortBy, bool ascending = true);
        
    }

}
