using Microsoft.AspNetCore.Identity;

namespace Home_Central.Models;


public class IdentityUserModel 
{
    public IdentityUser User { get; set; } = null!;
    public List<string> Roles { get; set; } = null!;
    public List<IdentityRole> AvailableRoles { get; set; } = null!;
}
