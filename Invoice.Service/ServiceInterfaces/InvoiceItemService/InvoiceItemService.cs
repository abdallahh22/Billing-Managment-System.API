using Invoice.Repositories.Interfaces;
using Invoice.Service.DTO_s;
using Invoice.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.InvoiceItemService
{
    public class InvoiceItemService : IInvoiceItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public InvoiceItemService(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<InvoiceItemDto> CreateAsync(InvoiceItemDto invoiceItemDto)
        {
            var invoiceItem = _mapper.MapToEntity(invoiceItemDto);
            await _unitOfWork.InvoiceItems.AddAsync(invoiceItem);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(invoiceItem);

        }

        public async Task<InvoiceItemDto> DeleteAsync(int id)
        {
            var invoiceItem = await _unitOfWork.InvoiceItems.GetByIdAsync(id);
            if (invoiceItem == null)
                throw new Exception("Id is null");
            await _unitOfWork.InvoiceItems.DeleteAsync(invoiceItem);
            await _unitOfWork.SaveAsync();

            return _mapper.MapToDto(invoiceItem);

        }

        public async Task<IEnumerable<InvoiceItemDto>> GetAllAsync()
        {
            var invoiceItems = await _unitOfWork.InvoiceItems.GetAllAsync();
            return invoiceItems.Select(invoice => _mapper.MapToDto(invoice));
        }

        public async Task<InvoiceItemDto> GetByIdAsync(int id)
        {
            var invoiceItem = await _unitOfWork.InvoiceItems.GetByIdAsync(id);
            if (invoiceItem == null)
                throw new Exception("id is null");
            await _unitOfWork.SaveAsync();

            return _mapper.MapToDto(invoiceItem);
        }

       

        public async Task<InvoiceItemDto> UpdateAsync(InvoiceItemDto invoiceItemDto)
        {
            var invoiceItem = _mapper.MapToEntity(invoiceItemDto);
            await _unitOfWork.InvoiceItems.UpdateAsync(invoiceItem);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(invoiceItem);
        }
    }
}
