using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.DTO_s
{
    public class InvoiceDto
    {
        public string? InvoiceNumber { get; set; }
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CompanyID { get; set; }
        public string? Status { get; set; }
        public DiscountDto? Discount { get; set; }
        public TaxDto? Tax { get; set; }
        public List<InvoiceItemDto>? InvoiceItems { get; set; }

    }

}
