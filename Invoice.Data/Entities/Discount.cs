using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Data.Entities
{
    public class Discount : BaseEntity<int>
    {
    
        public string? Description { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}