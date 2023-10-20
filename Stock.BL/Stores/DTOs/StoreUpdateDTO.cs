using System.ComponentModel.DataAnnotations;

namespace Stock.BL.Stores.DTOs;

public class StoreUpdateDTO
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Address { get; set; }
    public string MobileNumber { get; set; }
}
