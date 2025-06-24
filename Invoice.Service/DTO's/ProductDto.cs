using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.DTO_s
{
    public class ProductDto
    {
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int? StockQuantity { get; set; }
    }

}
