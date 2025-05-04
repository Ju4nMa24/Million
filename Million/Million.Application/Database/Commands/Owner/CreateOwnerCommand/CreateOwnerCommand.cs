using AutoMapper;
using Million.Domain.Entities.Owner;

namespace Million.Application.Database.Commands.Owner.CreateOwnerCommand
{
    /// <summary>
    /// Command to create a new owner in the database.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class CreateOwnerCommand(IDataBaseService db, IMapper mapper) : ICreateOwnerCommand
    {
        /// <summary>
        /// GLOBALS
        /// </summary>
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
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

            model.CreationDate = DateTime.UtcNow;
            model.ModificationDate = DateTime.UtcNow;

            var entity = _mapper.Map<OwnerEntity>(model);

            await _db.Owners.AddAsync(entity);
            await _db.SaveAsync();

            return model; // Retorna el modelo creado
        }
    }

}
