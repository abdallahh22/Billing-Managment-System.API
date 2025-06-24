using Invoice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Repositories.Interfaces
{

    public interface IProductRepository : IGenericRepository<Product>
    {
    Task<IEnumerable<Product>> GetProductsInStockAsync();
    }
}
