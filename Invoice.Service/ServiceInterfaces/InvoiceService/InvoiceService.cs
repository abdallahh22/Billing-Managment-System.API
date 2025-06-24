using Invoice.Repositories.Interfaces;
using Invoice.Repositories.Pagenations;
using Invoice.Repositories.Repositories;
using Invoice.Service.DTO_s;
using Invoice.Service.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.InvoiceService
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public InvoiceService(IUnitOfWork unitOfWork, Mapper mapper)
        {
           _unitOfWork = unitOfWork;
           _mapper = mapper;
        }
        public async Task<InvoiceDto> CreateAsync(InvoiceDto invoiceDto)
        {
            var invoice = _mapper.MapToEntity(invoiceDto);
            await _unitOfWork.Invoices.AddAsync(invoice);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(invoice);

        }

        public async Task<InvoiceDto> DeleteAsync(int id)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(id);
            if (invoice == null)
                throw new Exception("Id is Null");
            await _unitOfWork.Invoices.DeleteAsync(invoice);
            await _unitOfWork.SaveAsync();

            return _mapper.MapToDto(invoice);

        }


        public async Task<IEnumerable<InvoiceDto>> GetInvoicesAsync()
        {
            var invoice = await _unitOfWork.Invoices.GetAllAsync();
            return invoice.Select(invoice => _mapper.MapToDto(invoice));

        }
        public async Task<InvoiceDto> GetByIdAsync(int? id)
        {
            var invoice = await _unitOfWork.Invoices.GetByIdAsync(id);
            if (invoice == null)
                throw new Exception("Id is null");
            await _unitOfWork.SaveAsync();

            return _mapper.MapToDto(invoice);

        }

        public async Task<InvoiceDto> GetInvoiceWithDetailsAsync(int id)
        {
            var invoice = await _unitOfWork.Invoices.GetInvoiceWithDetailsAsync(id);
            if (invoice == null)
                throw new Exception("Invoice Not Found!");
            await _unitOfWork.SaveAsync();

            return _mapper.MapToDto(invoice);

        }

        public async Task<Pagenate<InvoiceDto>> GetPaginatedInvoicesAsync(int pageNumber, int pageSize, string? sortBy, bool ascending = true)
        {
            var paginatedInvoice = await _unitOfWork.Invoices.GetPaginatedInvoicesAsync(pageNumber, pageSize, sortBy, ascending);
            if (paginatedInvoice == null || !paginatedInvoice.Items.Any())
            {
                throw new Exception("No invoices found!");
            }

            var mappedInvoices = paginatedInvoice.Items.Select(invoice => _mapper.MapToDto(invoice)).ToList();

            var result = new Pagenate<InvoiceDto>
            {
                Items = mappedInvoices,
                TotalItems = paginatedInvoice.TotalItems,
                PageNumber = paginatedInvoice.PageNumber,
                PageSize = paginatedInvoice.PageSize
            };

            return result;
        }

        public async Task<InvoiceDto> UpdateAsync(InvoiceDto invoiceDto)
        {
            var invoice = _mapper.MapToEntity(invoiceDto);
            _unitOfWork.Invoices.UpdateAsync(invoice);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(invoice);

        }

       

    }
}
