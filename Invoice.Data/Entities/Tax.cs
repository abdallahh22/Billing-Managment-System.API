using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Data.Entities
{
    public class Tax : BaseEntity<int>
    {
        public string? TaxName { get; set; }
        public decimal TaxRate { get; set; }
        public string? Description { get; set; }
        [ForeignKey(nameof(Invoice))]
        public int? InvoiceID { get; set; }
        public Invoice? Invoice { get; set; }

    }
}
