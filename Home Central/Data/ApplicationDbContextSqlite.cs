using Home_Central.Data.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Home_Central.Data;

public class ApplicationDbContextSqlite : IdentityDbContext
{
    public ApplicationDbContextSqlite(DbContextOptions<ApplicationDbContextSqlite> options)
        : base(options)
    {
    }
    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          
	{
        base.OnConfiguring(optionsBuilder);
    }*/
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Seeding of data
        builder.ApplyConfiguration(new AspNetUsersSeeding());
    }
}