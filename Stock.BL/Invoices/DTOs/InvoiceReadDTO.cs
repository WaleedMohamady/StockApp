namespace Stock.BL.Invoices.DTOs;

public class InvoiceReadDTO
{
    public Guid Id { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime Date { get; set; }
    public Guid StoreId { get; set; }
    public Guid ItemId { get; set; }
    public int Quantity { get; set; }
}
