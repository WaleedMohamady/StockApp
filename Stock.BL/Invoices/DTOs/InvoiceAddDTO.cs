using System.ComponentModel.DataAnnotations;

namespace Stock.BL.Invoices.DTOs;

public class InvoiceAddDTO
{
    [Required]
    public string InvoiceNumber { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public Guid StoreId { get; set; }
    [Required]
    public Guid ItemId { get; set; }
    [Required]
    public int Quantity { get; set; }
}
