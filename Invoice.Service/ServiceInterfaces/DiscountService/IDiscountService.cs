using Invoice.Service.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.DiscountService
{
    public interface IDiscountService
    {
        Task<DiscountDto> CreateAsync(DiscountDto discountDto);
        Task<DiscountDto> UpdateAsync(DiscountDto discountDto);
        Task<DiscountDto> DeleteAsync(int? id);
        Task<DiscountDto> GetByIdAsync(int? id);
        Task<IEnumerable<DiscountDto>> GetAllAsync();
        
    }
}
