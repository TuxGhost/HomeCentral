using Microsoft.EntityFrameworkCore;
using HomeCentral.Data.Entities;
namespace HomeCentral.Data.Seeding
{
    public class LinkenSeeding : IEntityTypeConfiguration<Linken>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Linken> builder)
        {
            builder.HasData(
                new Linken
                {
                    Id = 1,
                    Name = "Link naar mijn volledige curriculum vitae",
                    Url = "https://cv.peterkuda.be",
                    Active = true,
                }
            );
                
        }
    }
}
