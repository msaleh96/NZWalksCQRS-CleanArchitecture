using Domain.Walks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class WalkConfiguration : IEntityTypeConfiguration<Walk>
{
    public void Configure(EntityTypeBuilder<Walk> builder)
    {
        builder.ToTable("Walks");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Name).IsRequired().HasMaxLength(100);

        builder.Property(w => w.Description).IsRequired().HasMaxLength(250);

        builder.Property(w => w.LengthInKm).IsRequired();

        builder.Property(w => w.WalkImageUrl).HasMaxLength(500);

        builder.HasOne(w => w.Difficulty)
            .WithMany()
            .HasForeignKey(w => w.DifficultyId);

        builder.HasOne(w => w.Region)
            .WithMany()
            .HasForeignKey(w => w.RegionId);
    }
}