using AutoMapper;
using Million.Domain.Entities.Address;

namespace Million.Application.Database.Commands.Address.CreateAddressCommand
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class CreateAddressCommand(IDataBaseService db, IMapper mapper) : ICreateAddressCommand
    {
        /// <summary>
        /// GLOBALS
        /// </summary>
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// This method is used to create a new address in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateAddressModel?> Execute(CreateAddressModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Street) || string.IsNullOrEmpty(model.City))
                return null;

            if (_db.Addresses.Any(e => e.ZipCode == model.ZipCode))
                return null;

            model.CreationDate = DateTime.UtcNow;
            model.ModificationDate = DateTime.UtcNow;

            await _db.Addresses.AddAsync(_mapper.Map<AddressEntity>(model));
            await _db.SaveAsync();

            return model;
        }
    }

}
