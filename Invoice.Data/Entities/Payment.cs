using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Data.Entities
{
    public class Payment : BaseEntity<int>
    {
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentStatus { get; set; }


        [ForeignKey(nameof(Invoice))]
        public int InvoiceID { get; set; }
        public Invoice? Invoice { get; set; }
    }
}