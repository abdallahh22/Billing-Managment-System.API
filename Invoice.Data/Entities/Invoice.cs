using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Data.Entities
{
    public class Invoice : BaseEntity<int>
    {
        public string? InvoiceNumber { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }
        public decimal TotalAmount { get; set; }
        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }
        public Company? Company { get; set; }  
        public string? Status { get; set; }
        public ICollection<InvoiceItem>? InvoiceItems { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public Discount? Discount { get; set; }
        public int? TaxID { get; set; }
        public Tax? Tax { get; set; }
        

    }
}
