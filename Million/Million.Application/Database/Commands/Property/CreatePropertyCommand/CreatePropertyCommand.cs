using AutoMapper;
using Million.Domain.Entities.Property;

namespace Million.Application.Database.Commands.Property.CreatePropertyCommand
{
    /// <summary>
    /// Command to create a new property.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class CreatePropertyCommand(IDataBaseService db, IMapper mapper) : ICreatePropertyCommand
    {
        /// <summary>
        /// GLOBALS
        /// </summary>
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// Creates a new property.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreatePropertyModel?> Execute(CreatePropertyModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Name) || model.Price <= 0)
                return null;

            if (_db.Properties.Any(e => e.CodeInternal == model.CodeInternal))
                return null;

            model.CreationDate = DateTime.UtcNow;
            model.ModificationDate = DateTime.UtcNow;

            await _db.Properties.AddAsync(_mapper.Map<PropertyEntity>(model));
            await _db.SaveAsync();

            return model;
        }
    }

}
