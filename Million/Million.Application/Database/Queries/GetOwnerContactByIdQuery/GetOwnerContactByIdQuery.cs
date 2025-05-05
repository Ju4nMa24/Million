using Million.Domain.Entities.OwnerContact;
using System.Data.Entity;

namespace Million.Application.Database.Queries.GetOwnerContactByIdQuery
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="db"></param>
    public class GetOwnerContactByIdQuery(IDataBaseService db) : IGetOwnerContactByIdQuery
    {
        /// <summary>
        /// GLOBALS
        /// </summary>
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// This method is used to get the owner contact by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OwnerContactEntity?> Execute(Guid id)
        {
            return await _db.OwnerContacts.FirstOrDefaultAsync(o => o.IdOwner == id);
        }
    }

}
