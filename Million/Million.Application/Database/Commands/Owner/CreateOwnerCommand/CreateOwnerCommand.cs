using AutoMapper;
using Million.Application.Database.Commands.Address.CreateAddressCommand;
using Million.Domain.Entities.Owner;

namespace Million.Application.Database.Commands.Owner.CreateOwnerCommand
{
    /// <summary>
    /// Command to create a new owner in the database.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class CreateOwnerCommand(IDataBaseService db, IMapper mapper, ICreateAddressCommand createAddressCommand) : ICreateOwnerCommand
    {
        /// <summary>
        /// GLOBALS
        /// </summary>
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        private readonly ICreateAddressCommand _createAddressCommand = createAddressCommand;

        /// <summary>
        /// Creates a new owner in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreateOwnerModel?> Execute(CreateOwnerModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Name) || model.Birthday == DateTime.MinValue)
                return null;


            if (_db.Owners.Any(e => e.Name == model.Name))
                return null;

            Task<CreateAddressModel?> resultAddress = _createAddressCommand.Execute(new CreateAddressModel
            {
                City = model.Address.City,
                Country = model.Address.Country,
                State = model.Address.State,
                Street = model.Address.Street,
                ZipCode = model.Address.ZipCode,
                CreationDate = DateTime.UtcNow,
                ModificationDate = DateTime.UtcNow
            });
            if(resultAddress != null && resultAddress.Result != null)
                model.IdAddress = resultAddress.Result.IdAddress;

            model.IdOwner = Guid.NewGuid();
            model.CreationDate = DateTime.UtcNow;
            model.ModificationDate = DateTime.UtcNow;

            await _db.Owners.AddAsync(_mapper.Map<OwnerEntity>(model));
            await _db.SaveAsync();

            return model;
        }
    }

}
