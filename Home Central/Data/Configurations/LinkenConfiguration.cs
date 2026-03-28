using Microsoft.EntityFrameworkCore;
using HomeCentral.Data.Entities;

namespace HomeCentral.Data.Configurations;

public class LinkenConfiguration : IEntityTypeConfiguration<Linken>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Linken> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Name).IsRequired();
        builder.HasIndex(i => i.Name).IsUnique();
        
        builder.Property(l => l.Url).IsRequired();
        builder.HasIndex(i => i.Url).IsUnique();
    }
}
