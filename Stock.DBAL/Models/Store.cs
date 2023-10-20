namespace Stock.DBAL.Models
{
    public class Store
    {
        public Store()
        {
            Invoices = new HashSet<Invoice>();
            StoreItems = new HashSet<StoreItem>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<StoreItem> StoreItems { get; set; }
    }
}
