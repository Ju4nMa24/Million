using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Million.Domain.Entities.OwnerContact;

namespace Million.Persistence.Configuration
{
    /// <summary>
    /// Configuration for OwnerContact details, representing owner's contact info.
    /// </summary>
    public class OwnerContactConfiguration : IEntityTypeConfiguration<OwnerContactEntity>
    {
        public void Configure(EntityTypeBuilder<OwnerContactEntity> builder)
        {
            builder.HasKey(x => x.IdContact);
            builder.Property(x => x.IdContact).HasMaxLength(36).HasDefaultValueSql("NEWID()");

            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(50);
        }
    }
}
