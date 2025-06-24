using Invoice.Data.Entities;
using Invoice.Repositories.Interfaces;
using Invoice.Service.DTO_s;
using Invoice.Service.Mapping;
using Invoice.Service.ServiceInterfaces.CompanyService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.CompaniesService
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CompanyDto> CreateAsync(CompanyDto CompanyDto)
        {
            var Companies = _mapper.MapToEntity(CompanyDto);
            
             await _unitOfWork.Companies.AddAsync(Companies);
            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.InnerException != null)
                throw; 
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
            return _mapper.MapToDto(Companies);
        }

        public async Task<CompanyDto> DeleteCompanyAsync(int? id)
        {
            
            var Companies = await _unitOfWork.Companies.GetByIdAsync(id);
            if (Companies == null)
                throw new Exception("Company not found");
            await _unitOfWork.Companies.DeleteAsync(Companies);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(Companies);

        }

      

        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            var Companies = await _unitOfWork.Companies.GetAllAsync();
            await _unitOfWork.SaveAsync();
            return Companies.Select(Companies => _mapper.MapToDto(Companies));

        }

        public async Task<CompanyDto> GetById(int? id)
        {
            
            var Companies = await _unitOfWork.Companies.GetByIdAsync(id);
            if (Companies is null)
                throw new Exception("Company not found");
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(Companies);

        }

        public async Task<CompanyDto> GetByName(int? CompaniesId)
        { 
            
            var Companies = await _unitOfWork.Companies.GetCompanyNameByIdAsync(CompaniesId);
            if (Companies is null)
                throw new Exception("Company Not found");
            return new CompanyDto
            {
                CompanyName = Companies
            };
        }

       

        public async Task<CompanyDto> UpdateCompanyAsync(CompanyDto CompanyDto)
        {
            var company = _mapper.MapToEntity(CompanyDto);
            await _unitOfWork.Companies.UpdateAsync(company);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(company);
        }


    }
}
