using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel;

namespace Home_Central.Data.Seeding;

public class AspNetUsersSeeding : IEntityTypeConfiguration<IdentityUser>
{
    public void Configure(EntityTypeBuilder<IdentityUser> builder)
    {
        builder.HasData(
                new IdentityUser
                {
                    UserName = "root@localhost",
                    Id = "fc6b6de0-abd9-493c-9fc0-cf728261ab09",
                    NormalizedUserName = "ROOT@LOCALHOST",
                    Email = "root@localhost",
                    NormalizedEmail = "ROOT@localhost",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAECGCcqKC8uTLYFmkqXuCTiHuuvy+7qi1AVr7/dP+GsNXcUTYbfRXeGJKQ4fEcqtszQ==", // paswoord Administrator123!
                }
            ); 
    }
}
