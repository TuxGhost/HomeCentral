namespace HomeCentral.Data;

using Microsoft.EntityFrameworkCore;
using HomeCentral.Data.Entities;
using HomeCentral.Data.Configurations;
public class HomeDbContextUpdate : DbContext
{
    public HomeDbContextUpdate() { }
     public HomeDbContextUpdate(DbContextOptions<HomeDbContextUpdate> options) : base(options) { }
     
     public DbSet<Linken> Linken { get; set; } = null!;
     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new LinkenConfiguration());
        modelBuilder.ApplyConfiguration(new Seeding.LinkenSeeding());
    }
}
