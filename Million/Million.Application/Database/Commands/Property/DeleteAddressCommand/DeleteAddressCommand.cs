using Million.Domain.Entities.Address;

namespace Million.Application.Database.Commands.Property.DeleteAddressCommand
{
    public class DeleteAddressCommand(IDataBaseService db) : IDeleteAddressCommand
    {
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// Delete address command.
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
