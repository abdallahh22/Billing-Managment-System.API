using Invoice.Data.Entities;
using Invoice.Repositories.Interfaces;
using Invoice.Service.DTO_s;
using Invoice.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.TaxService
{
    public class TaxService : ITaxesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public TaxService(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TaxDto> CreateAsync(TaxDto TaxDto)
        {
            var tax = _mapper.MapToEntity(TaxDto);
            await _unitOfWork.Taxes.AddAsync(tax);
            await _unitOfWork.SaveAsync();

            return _mapper.MapToDto(tax);
        }

        public async Task<TaxDto> DeleteAsync(int id)
        {
            var taxId = await _unitOfWork.Taxes.GetByIdAsync(id);
            if (taxId is null)
                throw new Exception("Id is null");
            await _unitOfWork.Taxes.DeleteAsync(taxId);
            await _unitOfWork.SaveAsync();

            return _mapper.MapToDto(taxId);

        }

        public async Task<IEnumerable<TaxDto>> GetAllAsync()
        {
            var tax = await _unitOfWork.Taxes.GetAllAsync();
            return tax.Select(tax => _mapper.MapToDto(tax));
        }

        public async Task<TaxDto> GetByIdAsync(int id)
        {
            var tax = await _unitOfWork.Taxes.GetByIdAsync(id);
            if (tax is null)
                throw new Exception("Id is null");
            return _mapper.MapToDto(tax);

        }

        

        public async Task<TaxDto> UpdateAsync(TaxDto TaxDto)
        {
            var tax = _mapper.MapToEntity(TaxDto);
            await _unitOfWork.Taxes.UpdateAsync(tax);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(tax);
        }
    }
}
