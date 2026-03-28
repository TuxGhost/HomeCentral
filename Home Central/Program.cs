using Home_Central.Areas.Identity;
using HomeCentral.Data;
using Home_Central.Data;
using Home_Central.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using HomeCentral.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();
builder.Logging.AddDebug();
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
    throw new InvalidOperationException("Could not connect to database");

var logging = builder.Configuration.GetValue<string>("LoggingEnabled", "false");
var swtKey = builder.Configuration.GetValue<string>("Jwt:SecretKey", "");

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<IEmailSender,SmtpService>();
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
    //options.UseSqlite(connectionString,o => o.MaxBatchSize(20)));
builder.Services.AddDbContext<ApplicationDbContext>(options =>   
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), o => o.MaxBatchSize(20)));
builder.Services.AddDbContext<WoningDbContext>(options =>
    options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));
// add language services
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("en"),
        new CultureInfo("en-US"),
        new CultureInfo("nl"),
        new CultureInfo("nl-BE"),
    };
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.DefaultRequestCulture = new RequestCulture("en");
});
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews()
        .AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder)
    .AddDataAnnotationsLocalization();
// enable logging depending on  value in appsettings.json (not standard)
if (logging == "true")
{
    builder.Services.AddDbContext<HomeDbContext>(options =>
        //options.UseSqlite(connectionString)
        options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString))
        .LogTo(Console.WriteLine ,
            new[] { DbLoggerCategory.Database.Command.Name } ,
            Microsoft.Extensions.Logging.LogLevel.Information,
            Microsoft.EntityFrameworkCore.Diagnostics.DbContextLoggerOptions.Level | 
            Microsoft.EntityFrameworkCore.Diagnostics.DbContextLoggerOptions.LocalTime)
        .EnableSensitiveDataLogging()
    );
    builder.Services.AddDbContext<HomeDbContextUpdate>(options =>        
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        .LogTo(Console.WriteLine,
            new[] { DbLoggerCategory.Database.Command.Name },
            Microsoft.Extensions.Logging.LogLevel.Information,
            Microsoft.EntityFrameworkCore.Diagnostics.DbContextLoggerOptions.Level |
            Microsoft.EntityFrameworkCore.Diagnostics.DbContextLoggerOptions.LocalTime)
        .EnableSensitiveDataLogging()
    );
} else
{
    builder.Services.AddDbContext<HomeDbContext>(options =>
        options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString))
    );
    builder.Services.AddDbContext<HomeDbContextUpdate>(options =>
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    );
}

builder.Services.AddTransient<IHomeService, HomeService>();
builder.Services.AddScoped<IUrlService, UrlService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
})
    .AddCookie(options =>
    {
        options.LoginPath = "/Identity/Account/Login";
        options.LogoutPath = "/Identity/Account/Logout";
        options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(swtKey)),
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddAuthorization();
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
app.UseRequestLocalization();
app.Use(async (context, next) =>
{
    var requestCultureFeature = context.Features.Get<IRequestCultureFeature>();    
    if(requestCultureFeature != null)
    {
        var currentCulture = context.Features.Get<IRequestCultureFeature>().RequestCulture.Culture;
        var currentUICulture = context.Features.Get<IRequestCultureFeature>().RequestCulture.UICulture;
        //console.writeline(localizer!.tostring());
        //console.writeline($"current culture : {cultureinfo.currentculture.name} , {cultureinfo.currentuiculture.name}");
        //console.writeline($"{requestculture.culture.name} , {requestculture.uiculture.name}");
        Console.WriteLine($"Request path: {context.Request.Path}");
        Console.WriteLine($"Request path: {context.Request.Host}");
        Console.WriteLine($"Request path: {context.Request.Method}");

        Console.WriteLine($"{currentCulture.Name} , {currentUICulture.Name}");
    }    
    await next();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// initialize database 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        //var context = services.GetRequiredService<ApplicationDbContext>();
        //context.Database.Migrate();
        //var homeContext = services.GetRequiredService<HomeDbContext>();
        //homeContext.Database.Migrate();
        var homeContextUpdate = services.GetRequiredService<HomeDbContextUpdate>();
        homeContextUpdate.Database.EnsureCreated();
        homeContextUpdate.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}

app.Run();
