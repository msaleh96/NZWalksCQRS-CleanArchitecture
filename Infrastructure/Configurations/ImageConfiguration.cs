using Domain.Image;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.FileName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(i => i.FileDescription)
            .HasMaxLength(500);

        builder.Property(i => i.FileExtension)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(i => i.FileSizeInBytes)
            .IsRequired();

        builder.Property(i => i.FilePath)
            .IsRequired()
            .HasMaxLength(500);
    }
}