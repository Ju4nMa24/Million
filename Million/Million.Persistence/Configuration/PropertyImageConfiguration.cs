using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Million.Domain.Entities.PropertyImage;

namespace Million.Persistence.Configuration
{
    /// <summary>
    /// Configuration for property image attachments.
    /// </summary>
    public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImageEntity>
    {
        public void Configure(EntityTypeBuilder<PropertyImageEntity> builder)
        {
            builder.HasKey(x => x.IdPropertyImage);
            builder.Property(x => x.IdPropertyImage).HasMaxLength(36).HasDefaultValueSql("NEWID()");

            builder.Property(x => x.File).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Enabled).IsRequired();
            builder.Property(x => x.UploadedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
