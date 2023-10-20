using System.ComponentModel.DataAnnotations;

namespace Stock.BL.Items.DTOs;

public class ItemAddDTO 
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int TotalBalance { get; set; }
}
