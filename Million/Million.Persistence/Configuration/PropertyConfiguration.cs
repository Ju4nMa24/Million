using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Million.Domain.Entities.Property;

namespace Million.Persistence.Configuration
{
    /// <summary>
    /// Configuration for the Property entity, linking to owner and address.
    /// </summary>
    public class PropertyConfiguration : IEntityTypeConfiguration<PropertyEntity>
    {
        public void Configure(EntityTypeBuilder<PropertyEntity> builder)
        {
            builder.HasKey(x => x.IdProperty);
            builder.Property(x => x.IdProperty).HasMaxLength(36).HasDefaultValueSql("NEWID()");

            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(x => x.CodeInternal).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Status).HasMaxLength(50);

            builder.HasIndex(x => x.CodeInternal).IsUnique();

            builder.HasOne(x => x.Owner)
                .WithMany(o => o.Properties)
                .HasForeignKey(x => x.IdOwner)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(x => x.Address)
                .WithMany(a => a.Properties)
                .HasForeignKey(x => x.IdAddress)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
