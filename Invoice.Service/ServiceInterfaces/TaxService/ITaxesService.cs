using Invoice.Service.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.TaxService
{
    public interface ITaxesService
    {
        Task<TaxDto> CreateAsync(TaxDto TaxDto);
        Task<TaxDto> UpdateAsync(TaxDto TaxDto);
        Task<TaxDto> DeleteAsync(int id);
        Task<TaxDto> GetByIdAsync(int id);
        Task<IEnumerable<TaxDto>> GetAllAsync();
       
    }
}
