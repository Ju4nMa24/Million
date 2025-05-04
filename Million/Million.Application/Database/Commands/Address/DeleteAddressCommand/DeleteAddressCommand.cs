using Million.Domain.Entities.Address;

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
            AddressEntity? addressEntity = await _db.Addresses.FindAsync(model.IdAddress);
            if (addressEntity == null) return false;

            _db.Addresses.Remove(addressEntity);
            await _db.SaveAsync();
            return true;
        }
    }
}
