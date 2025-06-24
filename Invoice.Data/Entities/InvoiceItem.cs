using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Data.Entities
{
    public class InvoiceItem : BaseEntity<int>
    {
        [ForeignKey(nameof(Invoice))]
        public int InvoiceID { get; set; }
        public Invoice? Invoice { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductID { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

    }
}