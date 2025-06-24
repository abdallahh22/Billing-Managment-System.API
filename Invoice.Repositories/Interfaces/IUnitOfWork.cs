using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        ICustomerRepository Customers { get; }
        IDiscountRepository Discounts { get; }
        IInvoicesRepository Invoices { get; }
        IInvoiceItemsRepository InvoiceItems { get; }
        IPaymentRepository Payments { get; }
        IProductRepository Products { get; }
        ITaxRepository Taxes { get; }
        Task<int> SaveAsync();
    }
}
