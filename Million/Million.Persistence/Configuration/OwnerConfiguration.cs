using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Million.Domain.Entities.Owner;

namespace Million.Persistence.Configuration
{
    /// <summary>
    /// Configuration for the Owner entity, with personal and relationship fields.
    /// </summary>
    public class OwnerConfiguration : IEntityTypeConfiguration<OwnerEntity>
    {
        public void Configure(EntityTypeBuilder<OwnerEntity> builder)
        {
            builder.HasKey(x => x.IdOwner);
            builder.Property(x => x.IdOwner).HasMaxLength(36).HasDefaultValueSql("NEWID()");

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Photo).HasMaxLength(255);
            builder.Property(x => x.Birthday).HasColumnType("DATE");

            builder.HasOne(x => x.Address).WithMany(a => a.Owners).HasForeignKey(x => x.IdAddress);
            builder.HasMany(x => x.Properties).WithOne(p => p.Owner).HasForeignKey(p => p.IdOwner);
            builder.HasMany(x => x.Contacts).WithOne(c => c.Owner).HasForeignKey(c => c.IdOwner);
        }
    }
}
