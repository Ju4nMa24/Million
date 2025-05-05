using Microsoft.EntityFrameworkCore;
using Million.Application.Database.Commands.Address.DeleteAddressCommand;
using Million.Domain.Entities.Owner;

namespace Million.Application.Database.Commands.Owner.DeleteOwnerCommand
{
    /// <summary>
    /// Command to delete an owner from the database.
    /// </summary>
    /// <param name="db"></param>
    public class DeleteOwnerCommand(IDataBaseService db, IDeleteAddressCommand deleteAddress) : IDeleteOwnerCommand
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        private readonly IDataBaseService _db = db;
        private readonly IDeleteAddressCommand _deleteAddress = deleteAddress;

        /// <summary>
        /// This method is used to delete the owner info in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Execute(DeleteOwnerModel model)
        {
            OwnerEntity? ownerEntity = await _db.Owners.FirstOrDefaultAsync(p => p.IdOwner == model.IdOwner);
            if (ownerEntity == null) return false;

            Task<bool> resultAddress = _deleteAddress.Execute(new DeleteAddressModel
            {
                IdAddress = ownerEntity.IdAddress
            });
            if (!resultAddress.Result) return false;

            _db.Owners.Remove(ownerEntity);
            await _db.SaveAsync();
            return true;
        }
    }
}
