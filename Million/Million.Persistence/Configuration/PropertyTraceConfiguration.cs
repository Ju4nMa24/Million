using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Million.Domain.Entities.PropertyTrace;

namespace Million.Persistence.Configuration
{
    /// <summary>
    /// Configuration for historical property trace records.
    /// </summary>
    public class PropertyTraceConfiguration : IEntityTypeConfiguration<PropertyTraceEntity>
    {
        public void Configure(EntityTypeBuilder<PropertyTraceEntity> builder)
        {
            builder.HasKey(x => x.IdPropertyTrace);
            builder.Property(x => x.IdPropertyTrace).HasMaxLength(36).HasDefaultValueSql("NEWID()");

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Value).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.Tax).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.DateSale).HasColumnType("DATE").IsRequired();
        }
    }
}
