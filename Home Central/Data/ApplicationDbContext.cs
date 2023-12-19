using Home_Central.Data.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Home_Central.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seeding of data
            builder.ApplyConfiguration(new AspNetUsersSeeding());
            builder.ApplyConfiguration(new AspNetRolesSeeding());
            builder.ApplyConfiguration(new AspNetUserRolesSeeding());
        }
    }
}