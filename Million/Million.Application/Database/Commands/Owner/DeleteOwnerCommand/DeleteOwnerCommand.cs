using Million.Domain.Entities.Owner;

namespace Million.Application.Database.Commands.Owner.DeleteOwnerCommand
{
    /// <summary>
    /// Command to delete an owner from the database.
    /// </summary>
    /// <param name="db"></param>
    public class DeleteOwnerCommand(IDataBaseService db) : IDeleteOwnerCommand
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// This method is used to delete the owner info in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Execute(DeleteOwnerModel model)
        {
            OwnerEntity? ownerEntity = await _db.Owners.FindAsync(model.IdOwner);
            if (ownerEntity == null) return false;

            _db.Owners.Remove(ownerEntity);
            await _db.SaveAsync();
            return true;
        }
    }
}
