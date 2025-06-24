using Invoice.Data.Entities;
using Invoice.Service.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.PaymentService
{
    public interface IPaymentService
    {
        Task<PaymentDto> GetPaymentByIdAsync(int paymentId);
        Task<PaymentDto> CreateAsync(PaymentDto PaymentDto);
        Task<PaymentDto> UpdateAsync(PaymentDto PaymentDto);
        Task<PaymentDto> DeleteAsync(int id);
        Task<PaymentDto> GetByIdAsync(int id);
        Task<IEnumerable<PaymentDto>> GetAllAsync();
        
    }
}
