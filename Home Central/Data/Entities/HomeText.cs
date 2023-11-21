using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Home_Central.Data.Entities;
public class HomeText
{
    [Key]
    public int Id { get; set; }
    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
    [Required,DefaultValue(true)]
    public bool IsActive {  get; set; }
}
