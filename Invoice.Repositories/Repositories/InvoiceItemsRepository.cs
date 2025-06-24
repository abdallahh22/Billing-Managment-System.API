using Invoice.Data.Context;
using Invoice.Data.Entities;
using Invoice.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Repositories.Repositories
{
    public class InvoiceItemsRepository : GenericRepository<InvoiceItem>, IInvoiceItemsRepository
    {
        public InvoiceItemsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
