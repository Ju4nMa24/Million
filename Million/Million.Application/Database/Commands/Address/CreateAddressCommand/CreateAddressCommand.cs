using Microsoft.EntityFrameworkCore;
using Million.Domain.Entities.Address;

namespace Million.Application.Database.Commands.Address.CreateAddressCommand
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="db"></param>
    public class CreateAddressCommand(IDataBaseService db) : ICreateAddressCommand
    {
        /// <summary>
        /// GLOBALS
        /// </summary>
        private readonly IDataBaseService _db = db;

        /// <summary>
        /// This method is used to create a new address in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateAddressModel?> Execute(CreateAddressModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Street) || string.IsNullOrEmpty(model.City))
                return null;

            // Buscar si ya existe una dirección igual
            AddressEntity existingAddress = await _db.Addresses
                .FirstOrDefaultAsync(a =>
                    a.Street == model.Street &&
                    a.City == model.City &&
                    a.State == model.State &&
                    a.ZipCode == model.ZipCode &&
                    a.Country == model.Country);

            if (existingAddress == null)
            {
                AddressEntity newAddress = new()
                {
                    City = model.City,
                    Country = model.Country,
                    State = model.State,
                    Street = model.Street,
                    ZipCode = model.ZipCode,
                    IdAddress = Guid.NewGuid()
                };
                model.CreationDate = DateTime.UtcNow;
                model.ModificationDate = DateTime.UtcNow;

                //await _db.Addresses.AddAsync(newAddress);
                //await _db.SaveAsync();
                model.IdAddress = newAddress.IdAddress;
            }
            if (existingAddress != null)
                model.IdAddress = existingAddress.IdAddress;
            return model;
        }

    }

}
