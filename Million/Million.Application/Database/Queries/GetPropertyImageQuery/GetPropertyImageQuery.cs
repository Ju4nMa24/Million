using Million.Domain.Entities.PropertyImage;

namespace Million.Application.Database.Queries.GetPropertyImageQuery
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public class GetPropertyImageQuery(IDataBaseService db) : IGetPropertyImageQuery
    {
        /// <summary>
        /// GLOBALS.
        /// </summary>
        private readonly IDataBaseService _db = db;

        /// <summary>
        /// This method is used to get a property image by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetPropertyImageModel?> Execute(Guid id)
        {
            PropertyImageEntity? entity = await _db.PropertyImages.FindAsync(id);
            if (entity == null) return null;

            return new GetPropertyImageModel
            {
                IdPropertyImage = entity.IdPropertyImage,
                File = entity.File,
                Enabled = entity.Enabled,
                UploadedAt = entity.UploadedAt
            };
        }
    }

}
