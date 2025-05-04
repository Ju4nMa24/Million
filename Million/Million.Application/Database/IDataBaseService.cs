using Million.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Million.Application.Database
{
    public interface IDataBaseService
    {
        #region DBSETs
        public DbSet<UserEntity> Users { get; set; }
        #endregion
        /// <summary>
        /// This method is used to save info.
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveAsync();
    }
}
