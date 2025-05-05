using Microsoft.EntityFrameworkCore;
using Million.Domain.Entities.Address;
using Million.Domain.Entities.Owner;

namespace Million.Application.Database.Commands.Address.DeleteAddressCommand
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="db"></param>
    public class DeleteAddressCommand(IDataBaseService db) : IDeleteAddressCommand
    {
        /// <summary>
        /// GLOBALS
        /// </summary>
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// This method is used to delete an address from the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Execute(DeleteAddressModel model)
        {
            OwnerEntity? owner = await _db.Owners.FirstOrDefaultAsync(o => o.IdOwner == model.IdOwner);

            if (owner == null)
                return false;

            AddressEntity? addressEntity = await _db.Addresses.FirstOrDefaultAsync(a => a.IdAddress == owner.IdAddress);
            if (addressEntity == null) return false;

            _db.Addresses.Remove(addressEntity);
            await _db.SaveAsync();
            return true;
        }
    }
}
