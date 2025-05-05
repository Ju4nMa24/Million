
using Microsoft.EntityFrameworkCore;

namespace Million.Application.Database.Commands.Property.DeleteAddressCommand
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="db"></param>
    public class DeletePropertyCommand(IDataBaseService db) : IDeletePropertyCommand
    {
        /// <summary>
        /// GLOBALS
        /// </summary>
        private readonly IDataBaseService _db = db;

        /// <summary>
        /// This method is used to delete the property from the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Execute(DeletePropertyModel model)
        {
            var propertyEntity = await _db.Properties.FirstOrDefaultAsync(p => p.IdProperty == model.IdProperty);
            if (propertyEntity == null) return false;

            _db.Properties.Remove(propertyEntity);
            await _db.SaveAsync();
            return true;
        }
    }
}
