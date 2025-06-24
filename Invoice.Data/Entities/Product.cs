namespace Invoice.Data.Entities
{
    public class Product : BaseEntity<int>
    {
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; } 
        public int? StockQuantity { get; set; } 
        public virtual ICollection<InvoiceItem>? InvoiceItems { get; set; }
    }
}