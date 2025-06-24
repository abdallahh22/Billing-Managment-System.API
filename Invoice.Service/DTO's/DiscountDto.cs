using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.DTO_s
{
    public class DiscountDto
    {
        
        public int InvoiceID { get; set; }
        public string? Description { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountAmount { get; set; }
    }

}
