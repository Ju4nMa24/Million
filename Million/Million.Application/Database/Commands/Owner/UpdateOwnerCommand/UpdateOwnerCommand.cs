using AutoMapper;

namespace Million.Application.Database.Commands.Owner.UpdateOwnerCommand
{
    /// <summary>
    /// This class is used to update the owner info in the database.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class UpdateOwnerCommand(IDataBaseService db, IMapper mapper) : IUpdateOwnerCommand
    {
        /// <summary>
        /// GLOBALS
        /// </summary>
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// This method is used to update the owner info in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<UpdateOwnerModel?> Execute(UpdateOwnerModel model)
        {
            var ownerEntity = await _db.Owners.FindAsync(model.IdOwner);
            if (ownerEntity == null) return null;

            _mapper.Map(model, ownerEntity);
            //ownerEntity.ModifiedAt = DateTime.UtcNow;
            _db.Owners.Update(ownerEntity);
            await _db.SaveAsync();
            return model;
        }
    }
}
