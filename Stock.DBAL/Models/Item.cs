namespace Stock.DBAL.Models
{
    public class Item
    {
        public Item()
        {
            Invoices = new HashSet<Invoice>();
            StoreItems = new HashSet<StoreItem>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalBalance { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<StoreItem> StoreItems { get; set; }
    }
}
