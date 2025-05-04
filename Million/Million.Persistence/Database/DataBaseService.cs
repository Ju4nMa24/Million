using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Million.Application.Database;
using Million.Domain.Entities;

namespace Million.Persistence.Database
{
    public class DataBaseService(DbContextOptions options) : IdentityDbContext<UserEntity>(options), IDataBaseService
    {
        #region DBSETs
        //DbSet<UserEntity> IDataBaseService.Users { get; set; }
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
        }

    }
}
