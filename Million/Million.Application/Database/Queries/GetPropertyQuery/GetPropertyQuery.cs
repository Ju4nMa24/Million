using System.Data.Entity.Migrations.Model;

namespace Million.Application.Database.Queries.GetPropertyQuery
{
    /// <summary>
    /// This class is used to get a property by id.
    /// </summary>
    /// <param name="db"></param>
    public class GetPropertyQuery(IDataBaseService db) : IGetPropertyQuery
    {
        /// <summary>
        /// GLOBALS.
        /// </summary>
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// This method is used to get a property by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetPropertyModel?> Execute(Guid id)
        {
            var entity = await _db.Properties.FindAsync(id);
            if (entity == null) return null;

            return new GetPropertyModel
            {
                IdProperty = entity.IdProperty,
                Name = entity.Name,
                Price = entity.Price,
                CodeInternal = entity.CodeInternal,
                Year = entity.Year,
                Status = entity.Status
            };
        }
    }

}
