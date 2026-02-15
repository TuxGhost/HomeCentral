using Home_Central.Data.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Home_Central.Data
{
    public class SqLiteApplicationDbContext : IdentityDbContext
    {
        //public SqLiteApplicationDbContext(DbContextOptions<SqLiteApplicationDbContext> options)
        //    : base(options)
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=HomeCentral.db");
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seeding of data
            builder.ApplyConfiguration(new AspNetUsersSeeding());
        }
    }
}