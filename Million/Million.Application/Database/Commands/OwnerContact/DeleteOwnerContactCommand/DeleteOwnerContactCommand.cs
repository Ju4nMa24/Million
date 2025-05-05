using Microsoft.EntityFrameworkCore;
using Million.Domain.Entities.OwnerContact;

namespace Million.Application.Database.Commands.OwnerContact.DeleteOwnerContactCommand
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="db"></param>
    public class DeleteOwnerContactCommand(IDataBaseService db) : IDeleteOwnerContactCommand
    {
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// This method is used to delete owner contact by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Execute(Guid id)
        {
            OwnerContactEntity? entity = await _db.OwnerContacts.FirstOrDefaultAsync(o => o.IdOwner == id);
            if (entity == null) return false;

            _db.OwnerContacts.Remove(entity);
            await _db.SaveAsync();
            return true;
        }
    }

}
