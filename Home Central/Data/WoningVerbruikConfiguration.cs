using Home_Central.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home_Central.Data;

public class WoningVerbruikConfiguration : IEntityTypeConfiguration<WoningVerbruikModel>
{
    public void Configure(EntityTypeBuilder<WoningVerbruikModel> builder)
    {
        builder.ToTable("WoningVerbruik");                   
    }
}
