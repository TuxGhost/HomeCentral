using Home_Central.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Home_Central.Data;

public class WoningDbContext : DbContext
{
    public DbSet<WoningVerbruikModel> WoningVerbruik { get; set; } = null!;

    public WoningDbContext(DbContextOptions<WoningDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new WoningVerbruikConfiguration());
    }
}
