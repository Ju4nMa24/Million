using AutoMapper;
using Million.Domain.Entities.Address;
using Million.Domain.Entities.Owner;

namespace Million.Application.Database.Commands.Address.UpdateAddressCommand
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class UpdateAddressCommand(IDataBaseService db, IMapper mapper) : IUpdateAddressCommand
    {
        /// <summary>
        /// GLOBALS
        /// </summary>
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// This method updates an address in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<UpdateAddressModel?> Execute(UpdateAddressModel model)
        {
            AddressEntity? addressEntity = await _db.Addresses.FindAsync(model.IdAddress);
            if (addressEntity == null) return null;

            _mapper.Map(model, addressEntity);
            _db.Addresses.Update(addressEntity);
            await _db.SaveAsync();
            return model;
        }
    }
}
