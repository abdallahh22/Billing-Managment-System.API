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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsInStockAsync()
        {
            return await _context.Products
                .Where(p => p.StockQuantity > 0)
                .ToListAsync();
        }

    }
}
