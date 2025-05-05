using Microsoft.EntityFrameworkCore;
using Million.Domain.Entities.PropertyImage;

namespace Million.Application.Database.Commands.PropertyImage.DeletePropertyImageCommand
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="db"></param>
    public class DeletePropertyImageCommand(IDataBaseService db) : IDeletePropertyImageCommand
    {
        /// <summary>
        /// GLOBALS.
        /// </summary>
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// This method is used to delete property image from database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Execute(DeletePropertyImageModel model)
        {
            PropertyImageEntity? propertyImageEntity = await _db.PropertyImages.FirstOrDefaultAsync(p => p.IdPropertyImage == model.IdPropertyImage);
            if (propertyImageEntity == null) return false;

            _db.PropertyImages.Remove(propertyImageEntity);
            await _db.SaveAsync();
            return true;
        }
    }
}
