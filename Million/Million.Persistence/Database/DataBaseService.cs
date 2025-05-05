using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Million.Application.Database;
using Million.Domain.Entities;
using Million.Domain.Entities.Address;
using Million.Domain.Entities.Owner;
using Million.Domain.Entities.OwnerContact;
using Million.Domain.Entities.Property;
using Million.Domain.Entities.PropertyImage;
using Million.Domain.Entities.PropertyTrace;
using Million.Persistence.Configuration;

namespace Million.Persistence.Database
{
    public class DataBaseService(DbContextOptions options) : IdentityDbContext<UserEntity>(options), IDataBaseService
    {
        #region DBSETs
        DbSet<UserEntity> IDataBaseService.Users { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<OwnerContactEntity> OwnerContacts { get; set; }
        public DbSet<PropertyEntity> Properties { get; set; }
        public DbSet<PropertyImageEntity> PropertyImages { get; set; }
        public DbSet<PropertyTraceEntity> PropertyTraces { get; set; }

        #endregion
        /// <summary>
        /// This method is used to save info.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
        /// <summary>
        ///  Model Creating...   
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }
        /// <summary>
        /// Configuration models.
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void EntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerContactConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyImageConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyTraceConfiguration());
        }

    }
}
