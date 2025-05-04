using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Million.Domain.Entities.Address;

namespace Million.Persistence.Configuration
{
    /// <summary>
    /// Configuration for the Address entity, including required properties and navigation.
    /// </summary>
    public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.HasKey(x => x.IdAddress);
            builder.Property(x => x.IdAddress)
                   .HasMaxLength(36)
                   .HasDefaultValueSql("NEWID()");

            builder.Property(x => x.Street).IsRequired().HasMaxLength(150);
            builder.Property(x => x.City).IsRequired().HasMaxLength(100);
            builder.Property(x => x.State).HasMaxLength(100);
            builder.Property(x => x.ZipCode).HasMaxLength(20);
            builder.Property(x => x.Country).HasMaxLength(100);

            builder.HasMany(x => x.Owners).WithOne(o => o.Address).HasForeignKey(o => o.IdAddress);
            builder.HasMany(x => x.Properties).WithOne(p => p.Address).HasForeignKey(p => p.IdAddress);
        }
    }
}
