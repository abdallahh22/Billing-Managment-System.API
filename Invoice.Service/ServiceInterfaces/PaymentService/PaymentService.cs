using Invoice.Data.Entities;
using Invoice.Repositories.Interfaces;
using Invoice.Service.DTO_s;
using Invoice.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaymentDto> GetPaymentByIdAsync(int paymentId)
        {
            var payment = await _unitOfWork.Payments.GetPaymentByIdAsync(paymentId);
            if (payment == null)
                throw new Exception("Payment not found");
            return _mapper.MapToDto(payment);

        }

        public async Task<PaymentDto> CreateAsync(PaymentDto paymentDto)
        {
            var payment = _mapper.MapToEntity(paymentDto);
            await _unitOfWork.Payments.AddAsync(payment);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(payment);
        }

        public async Task<PaymentDto> UpdateAsync(PaymentDto paymentDto)
        {
            var payment = _mapper.MapToEntity(paymentDto);
            _mapper.MapToEntity(paymentDto);
            await _unitOfWork.Payments.UpdateAsync(payment);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(payment);

        }

        public async Task<PaymentDto> DeleteAsync(int id)
        {
            var payment = await _unitOfWork.Payments.GetPaymentByIdAsync(id);
            if (payment == null)
                throw new Exception("Payment not found");

            await _unitOfWork.Payments.DeleteAsync(payment);
            return _mapper.MapToDto(payment);
        }

        public async Task<PaymentDto> GetByIdAsync(int id)
        {
            var payment = await _unitOfWork.Payments.GetPaymentByIdAsync(id);
            if (payment == null)
                throw new Exception("Payment not found");
            await _unitOfWork.SaveAsync();

            return _mapper.MapToDto(payment);

        }

        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            var payments = await _unitOfWork.Payments.GetAllAsync();
            return payments.Select(payments => _mapper.MapToDto(payments));

        }

       
    }

}
