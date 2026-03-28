using Home_Central.Data.Entities;
using HomeCentral.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Home_Central.Data;

public class HomeDbContext : DbContext
{
    public HomeDbContext() { }
    public HomeDbContext(DbContextOptions<HomeDbContext> options) : base(options) { }
    public DbSet<HomeText> HomeTexts { get; set; } = null!;
    public DbSet<Linken> Linken { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
