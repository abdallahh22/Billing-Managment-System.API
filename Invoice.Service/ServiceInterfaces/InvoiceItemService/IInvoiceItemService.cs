using Invoice.Service.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.InvoiceItemService
{
    public interface IInvoiceItemService
    {
        Task<InvoiceItemDto> CreateAsync(InvoiceItemDto invoiceItemDto);
        Task<InvoiceItemDto> UpdateAsync(InvoiceItemDto invoiceItemDto);
        Task<InvoiceItemDto> DeleteAsync(int id);
        Task<InvoiceItemDto> GetByIdAsync(int id);
        Task<IEnumerable<InvoiceItemDto>> GetAllAsync();
       
    }
}
