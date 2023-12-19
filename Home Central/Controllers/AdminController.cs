using Home_Central.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Home_Central.Controllers;

[Authorize]
public class AdminController : Controller
{
    private readonly ApplicationDbContext context;
    public AdminController(ApplicationDbContext context)
    {
        this.context = context;
    }
    public async Task<IActionResult> Index()
    {
        var users = await context.Users.ToListAsync();        
        return View(users);
    }
    public async Task<IActionResult> Users()
    {
        var users = await context.Users.ToListAsync();
        return View(users);
    }
    public async Task <IActionResult> Roles()
    {
        var roles = await context.Roles.ToListAsync();
        return View(roles);
    }
    public async Task<IActionResult> UserRoles()
    {
        var userroles = await context.UserRoles.ToListAsync();
        return View(userroles);
    }
    public IActionResult Details()
    {
        return View();
    }
}
