using Home_Central.Data;
using Home_Central.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Could not connect to database");

var logging = builder.Configuration.GetValue<string>("LoggingEnabled", "false");

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<IEmailSender,SmtpService>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(connectionString));
builder.Services.AddDbContext<WoningDbContext>(options =>
    options.UseMySQL(connectionString));
// enable logging depending on  value in appsettings.json (not standard)
if (logging == "true")
{
    builder.Services.AddDbContext<HomeDbContext>(options =>
        options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine ,
            new[] { DbLoggerCategory.Database.Command.Name } ,
            Microsoft.Extensions.Logging.LogLevel.Information,
            Microsoft.EntityFrameworkCore.Diagnostics.DbContextLoggerOptions.Level | 
            Microsoft.EntityFrameworkCore.Diagnostics.DbContextLoggerOptions.LocalTime)
        .EnableSensitiveDataLogging()
    );
} else
{
    builder.Services.AddDbContext<HomeDbContext>(options =>
        options.UseMySQL(connectionString)
    );
}

builder.Services.AddTransient<IHomeService, HomeService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseMigrationsEndPoint();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
