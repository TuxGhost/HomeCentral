﻿using Home_Central.Data;
using Home_Central.Models;
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
    public  async Task<IActionResult> UserDetail(string Id)
    {
        IdentityUserModel user = new IdentityUserModel();        
        user.User = await context.Users.FindAsync(Id)!;
        if(user.User != null)
        {
            user.Roles = await context.UserRoles
                .Where(ur => ur.UserId ==  Id)
                .Join(context.Roles, ur => ur.RoleId , r=> r.Id , (ur,r) => r.Name)
                .ToListAsync();

        }
        user.AvailableRoles = await context.Roles.ToListAsync();
        return View(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddRole(string userid, string selectedRoleId)
    {
        var nw = new IdentityUserRole<string> {
            RoleId = selectedRoleId,
            UserId = userid
        };
        context.UserRoles.Add(nw);
        _ = await context.SaveChangesAsync();

        return View(nameof(Index));
    }
    [HttpPost]
    public async Task<IActionResult> RemoveRole(string userid, string rolename)
    {
        var dbRole = await context.Roles.Where(r => r.Name == rolename).FirstOrDefaultAsync();
        var nw = new IdentityUserRole<string>
        {
            RoleId = dbRole.Id.ToString(),
            UserId = userid
        };
        context.UserRoles.Remove(nw);
        _ = await context.SaveChangesAsync();

        return View(nameof(Index));
    }
}
