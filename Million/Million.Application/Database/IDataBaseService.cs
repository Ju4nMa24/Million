using Million.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Million.Domain.Entities.Address;
using Million.Domain.Entities.Owner;
using Million.Domain.Entities.Property;
using Million.Domain.Entities.PropertyImage;
using Million.Domain.Entities.PropertyTrace;
using Million.Domain.Entities.OwnerContact;

namespace Million.Application.Database
{
    public interface IDataBaseService
    {
        #region DBSETs
        public DbSet<UserEntity> Users { get; set; }
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
        Task<bool> SaveAsync();
    }
}
