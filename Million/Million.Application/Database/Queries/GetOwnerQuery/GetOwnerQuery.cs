using Million.Domain.Entities.Owner;

namespace Million.Application.Database.Queries.GetOwnerQuery
{
    /// <summary>
    /// Query to get an owner by id.
    /// </summary>
    /// <param name="db"></param>
    public class GetOwnerQuery(IDataBaseService db) : IGetOwnerQuery
    {
        /// <summary>
        /// GLOBALS 
        /// </summary>
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// This method is used to get an owner by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetOwnerModel?> Execute(Guid id)
        {
            OwnerEntity? entity = await _db.Owners.FindAsync(id);
            if (entity == null) return null;

            return new GetOwnerModel
            {
                IdOwner = entity.IdOwner,
                Name = entity.Name,
                Birthday = entity.Birthday,
                Photo = entity.Photo,
                IdAddress = entity.IdAddress
            };
        }
    }

}
