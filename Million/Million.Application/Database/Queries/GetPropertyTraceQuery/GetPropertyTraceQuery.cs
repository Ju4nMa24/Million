using Million.Domain.Entities.PropertyTrace;

namespace Million.Application.Database.Queries.GetPropertyTraceQuery
{
    /// <summary>
    /// Constructorl.
    /// </summary>
    /// <param name="db"></param>
    public class GetPropertyTraceQuery(IDataBaseService db) : IGetPropertyTraceQuery
    {
        /// <summary>
        /// GLOBALS.
        /// </summary>
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// This method is used to get a property trace by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetPropertyTraceModel?> Execute(Guid id)
        {
            PropertyTraceEntity? entity = await _db.PropertyTraces.FindAsync(id);
            if (entity == null) return null;

            return new GetPropertyTraceModel
            {
                IdPropertyTrace = entity.IdPropertyTrace,
                DateSale = entity.DateSale,
                Name = entity.Name,
                Value = entity.Value,
                Tax = entity.Tax
            };
        }
    }

}
