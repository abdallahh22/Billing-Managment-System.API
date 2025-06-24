using Invoice.Service.DTO_s;
using Invoice.Service.ServiceInterfaces.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateAsync([FromBody] ProductDto productDto)
          => Ok(await _productService.CreateAsync(productDto));

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllAsync()
         => Ok(await _productService.GetAllAsync());

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
         => Ok(await _productService.GetByIdAsync(id));

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(int? id, [FromBody] ProductDto productDto)
        => Ok(await _productService.UpdateAsync(productDto));

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(int id)
         => Ok(await _productService.DeleteAsync(id));

        [HttpGet("ProductInStock")]
        public async Task<IActionResult> GetProductsInStockAsync(int? id)
         => Ok(await _productService.GetProductsInStockAsync(id));
    }
}
