using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Home_Central.Models;

public class RoleViewModel
{
    public List<IdentityRole> Roles { get; set; } = null!;
    [MinLength(3)]
    public string RoleName { get; set; } = string.Empty;

}
