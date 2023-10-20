namespace Stock.DBAL.Models
{
    public class StoreItem
    {
        public Guid StoreId { get; set; }
        public Guid ItemId { get; set; }
        public int AvailableBalance { get; set; }
        public virtual Store Store { get; set; }
        public virtual Item Item { get; set; }
    }
}
