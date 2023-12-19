
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HomeCentral_Migration_SqLite;

public class SqLiteDbContext : IdentityDbContext
{
    public static IConfiguration configuration = null!;
    string connection = "Default";
  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (!optionsBuilder.IsConfigured)
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();
            var connectionString = configuration.GetConnectionString(connection);
            if (connectionString != null)
            {
                optionsBuilder.UseSqlite(connectionString);
            }
        }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // seeding of data
        //builder.ApplyConfiguration(new AspNetUsersSeeding());
    }
}
