using Home_Central.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public IActionResult Details()
    {
        return View();
    }
}
