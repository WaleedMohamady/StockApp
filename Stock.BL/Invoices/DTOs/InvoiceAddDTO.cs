using System.ComponentModel.DataAnnotations;

namespace Stock.BL.Invoices.DTOs;

public class InvoiceAddDTO
{
    [Required]
    public string InvoiceNumber { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Store is required")]
    public Guid StoreId { get; set; }
    [Required(ErrorMessage = "Item is required")]
    public Guid ItemId { get; set; }
    [Required]
    public int Quantity { get; set; }
}
