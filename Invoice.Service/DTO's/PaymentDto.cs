using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.DTO_s
{
    public class PaymentDto
    {
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }
        public int InvoiceID { get; set; }
    }

}
