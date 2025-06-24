using Invoice.Data.Entities;
using Invoice.Repositories.Interfaces;
using Invoice.Service.DTO_s;
using Invoice.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.ServiceInterfaces.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateAsync(ProductDto ProductDto)
        {
            var product = _mapper.MapToEntity(ProductDto);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(product);
        }

        public async Task<ProductDto> DeleteAsync(int id)
        {
            var productId = await _unitOfWork.Products.GetByIdAsync(id);
            if (productId is null)
                throw new Exception("Id is null");
            await _unitOfWork.Products.DeleteAsync(productId);
            await _unitOfWork.SaveAsync();

            return _mapper.MapToDto(productId);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var Product = await _unitOfWork.Products.GetAllAsync();
            return Product.Select(Product => _mapper.MapToDto(Product));
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product is null)
                throw new Exception("Id is null");
            return _mapper.MapToDto(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsInStockAsync(int? id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product is null)
                throw new Exception("Id is null");
            await _unitOfWork.Products.GetProductsInStockAsync();
            var productDto = _mapper.MapToDto(product);
            return new List<ProductDto> { productDto };

        }

       

        public async Task<ProductDto> UpdateAsync(ProductDto ProductDto)
        {
            
            var product = _mapper.MapToEntity(ProductDto);
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.SaveAsync();
            return _mapper.MapToDto(product);

        }
    }
}
