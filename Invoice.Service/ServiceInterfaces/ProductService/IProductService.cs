using Invoice.Data.Entities;
using Invoice.Service.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.ProductService
{
    public interface IProductService
    {
        Task<ProductDto> CreateAsync(ProductDto ProductDto);
        Task<ProductDto> UpdateAsync(ProductDto ProductDto);
        Task<ProductDto> DeleteAsync(int id);
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
       Task<IEnumerable<ProductDto>> GetProductsInStockAsync(int? id);
        
    }
}
