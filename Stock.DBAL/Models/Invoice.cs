namespace Stock.DBAL.Models
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public Guid StoreId { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public virtual Store Store { get; set; }
        public virtual Item Item { get; set; }
    }
}
