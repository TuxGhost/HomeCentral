using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;
namespace Home_Central.Data.Seeding;

public class AspNetUserRolesSeeding : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
             new IdentityUserRole<string>
             {
                 RoleId = "0cadf322-9281-4f3b-aa8a-88d16dd7ff86", // Replace with your role ID
                 UserId = "fc6b6de0-abd9-493c-9fc0-cf728261ab09"  // Replace with your user ID
             }
            );
    }
}
