using Invoice.Data.Entities;
using Invoice.Repositories.Interfaces;
using Invoice.Service.DTO_s;
using Invoice.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.DiscountService
{
    public class DiscountService : IDiscountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public DiscountService(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DiscountDto> CreateAsync(DiscountDto discountDto)
        {
            var discount = _mapper.MapToEntity(discountDto);
            await _unitOfWork.Discounts.AddAsync(discount);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(discount);
        }

        public async Task<DiscountDto> UpdateAsync(DiscountDto discountDto)
        {
            var updateDiscount = _mapper.MapToEntity(discountDto);
           await _unitOfWork.Discounts.UpdateAsync(updateDiscount);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(updateDiscount);
        }

        public async Task<DiscountDto> DeleteAsync(int? id)
        {
            var discount = await _unitOfWork.Discounts.GetByIdAsync(id);
            if (discount == null)
                throw new Exception("Discount not found");
            await _unitOfWork.Discounts.DeleteAsync(discount);
            return _mapper.MapToDto(discount);

        }

        public async Task<DiscountDto> GetByIdAsync(int? id)
        {
            var discount = await _unitOfWork.Discounts.GetByIdAsync(id);
            if (discount == null)
                throw new Exception("Discount not found");
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(discount);

        }

        public async Task<IEnumerable<DiscountDto>> GetAllAsync()
        {
            var discounts = await _unitOfWork.Discounts.GetAllAsync();
            return discounts.Select(discounts => _mapper.MapToDto(discounts));
        }

       
    }
}
