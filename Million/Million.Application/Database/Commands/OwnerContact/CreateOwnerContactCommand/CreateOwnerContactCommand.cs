using Million.Domain.Entities.OwnerContact;

namespace Million.Application.Database.Commands.OwnerContact.CreateOwnerContactCommand
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="db"></param>
    public class CreateOwnerContactCommand(IDataBaseService db) : ICreateOwnerContactCommand
    {
        /// <summary>
        /// GLOBALS.
        /// </summary>
        private readonly IDataBaseService _db = db;
        /// <summary>
        /// This method is used to create a new owner contact in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateOwnerContactModel?> Execute(CreateOwnerContactModel model)
        {
            if (model == null)
                return null;

            OwnerContactEntity entity = new()
            {
                IdContact = Guid.NewGuid(),
                Email = model.Email,
                Phone = model.Phone,
                Type = model.Type,
                IdOwner = model.IdOwner
            };

            await _db.OwnerContacts.AddAsync(entity);
            await _db.SaveAsync();
            return model;
        }
    }

}
