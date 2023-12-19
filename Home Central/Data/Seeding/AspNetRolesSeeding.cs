using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Home_Central.Data.Seeding;

public class AspNetRolesSeeding : IEntityTypeConfiguration<IdentityRole>
{   
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "0cadf322-9281-4f3b-aa8a-88d16dd7ff86",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
            }
            );
    }
}
