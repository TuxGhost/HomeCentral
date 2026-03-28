using System.ComponentModel.DataAnnotations;

namespace HomeCentral.Data.Entities;

public class Linken
{
    [Key]
    public int Id { get; set; }
    [Required]    
    public string Name { get; set; } = null!;
    [Required]
    public string Url { get; set; } = null!;
    [Required]
    public bool Active { get; set; } = true;    
}
