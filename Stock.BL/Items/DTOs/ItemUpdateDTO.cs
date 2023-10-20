using System.ComponentModel.DataAnnotations;

namespace Stock.BL.Items.DTOs;

public class ItemUpdateDTO
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int TotalBalance { get; set; }
}
