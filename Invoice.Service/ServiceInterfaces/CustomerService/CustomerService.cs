using Invoice.Data.Entities;
using Invoice.Repositories.Interfaces;
using Invoice.Service.DTO_s;
using Invoice.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CustomerDto> CreateCustomerAsync(CustomerDto customerDto)
        {
            var customer = _mapper.MapToEntity(customerDto);
            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(customer);

        }

        public async Task<CustomerDto> DeleteCustomerAsync(int? id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer is null)
                throw new Exception("Customer Not Found");
            await _unitOfWork.Customers.DeleteAsync(customer);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(customer);

        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customer = await _unitOfWork.Customers.GetAllAsync();
            await _unitOfWork.SaveAsync();
            return customer.Select(Customer => _mapper.MapToDto(Customer));
        }

        public async Task<CustomerDto> GetByIdAsync(int? id)
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);
            if (customer == null)
                throw new Exception("Id is null");
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(customer);
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomersByCompanyAsync(int? id)
        {
            var customer = await _unitOfWork.Customers.GetCustomersByCompanyAsync(id);
            if (customer == null)
                throw new Exception("Id is null");
            await _unitOfWork.SaveAsync();
            return customer.Select(Customer => _mapper.MapToDto(Customer));

        }

        public async Task<CustomerDto> UpdateCustomerAsync(CustomerDto customerDto)
        {
            var customer = _mapper.MapToEntity(customerDto);
            _unitOfWork.Customers.UpdateAsync(customer);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(customer);
        }
       
    }
}
