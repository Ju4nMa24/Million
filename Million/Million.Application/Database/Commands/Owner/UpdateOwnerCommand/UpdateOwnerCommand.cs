using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Million.Application.Database.Commands.Address.UpdateAddressCommand;
using Million.Domain.Entities.Owner;
using Million.Domain.Entities.OwnerContact;

namespace Million.Application.Database.Commands.Owner.UpdateOwnerCommand
{
    /// <summary>
    /// This class is used to update the owner info in the database.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class UpdateOwnerCommand(IDataBaseService db, IMapper mapper,IUpdateAddressCommand updateAddress) : IUpdateOwnerCommand
    {
        /// <summary>
        /// GLOBALS
        /// </summary>
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        private readonly IUpdateAddressCommand _updateAddress = updateAddress;
        /// <summary>
        /// This method is used to update the owner info in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<UpdateOwnerModel?> Execute(UpdateOwnerModel model)
        {
            OwnerContactEntity? contact = await _db.OwnerContacts.FirstOrDefaultAsync(o => o.Email == model.OldEmail);
            if (contact == null)
                return null;

            OwnerEntity? ownerEntity = await _db.Owners.FirstOrDefaultAsync(o => o.IdOwner == contact.IdOwner);
            if (ownerEntity == null) return null;

            if (model.Address == null)
                return null;

            Task<UpdateAddressModel?> resultAddress = _updateAddress.Execute(new UpdateAddressModel
            {
                City = model.Address?.City,
                Country = model.Address?.Country,
                State = model.Address?.State,
                Street = model.Address?.Street,
                ZipCode = model.Address?.ZipCode,
                IdAddress = ownerEntity.IdAddress
            });

            if (resultAddress.Result == null)
                return null;

            ownerEntity.Photo = model.Photo;
            ownerEntity.Birthday = model.Birthday;
            ownerEntity.Name = model.Name;
            _db.Owners.Update(ownerEntity);
            await _db.SaveAsync();
            model.IdOwner = ownerEntity.IdOwner;
            return model;
        }
    }
}
