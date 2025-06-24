using Invoice.Data.Context;
using Invoice.Repositories.Interfaces;
using Invoice.Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ICompanyRepository Companies => new CompanyRepository(_context);
        public ICustomerRepository Customers => new CustomerRepository(_context);
        public IDiscountRepository Discounts => new DiscountRepository(_context);
        public IInvoicesRepository Invoices => new InvoicesRepository(_context);
        public IInvoiceItemsRepository InvoiceItems => new InvoiceItemsRepository(_context);
        public IPaymentRepository Payments => new PaymentRepository(_context);
        public IProductRepository Products => new ProductRepository(_context);
        public ITaxRepository Taxes => new TaxRepository(_context);

        public async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
