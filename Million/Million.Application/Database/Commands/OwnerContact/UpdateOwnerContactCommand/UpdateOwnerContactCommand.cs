using Million.Domain.Entities.OwnerContact;

namespace Million.Application.Database.Commands.OwnerContact.UpdateOwnerContactCommand
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="db"></param>
    public class UpdateOwnerContactCommand(IDataBaseService db) : IUpdateOwnerContactCommand
    {
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// This method is used to update the owner contact info.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<UpdateOwnerContactModel?> Execute(UpdateOwnerContactModel model)
        {
            OwnerContactEntity? entity = await _db.OwnerContacts.FindAsync(model.IdContact);
            if (entity == null) return null;

            entity.Email = model.Email;
            entity.Phone = model.Phone;
            entity.Type = model.Type;

            await _db.SaveAsync();
            return model;
        }
    }

}
