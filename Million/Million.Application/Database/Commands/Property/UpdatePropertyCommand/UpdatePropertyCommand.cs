using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Million.Application.Database.Commands.Property.UpdatePropertyCommand
{
    /// <summary>
    /// Update property command.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class UpdatePropertyCommand(IDataBaseService db, IMapper mapper) : IUpdatePropertyCommand
    {
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// Update property command.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<UpdatePropertyModel?> Execute(UpdatePropertyModel model)
        {
            var propertyEntity = await _db.Properties.FirstOrDefaultAsync(p => p.IdProperty == model.IdProperty);
            if (propertyEntity == null) return null;

            _mapper.Map(model, propertyEntity);
            //propertyEntity.ModifiedAt = DateTime.UtcNow;
            _db.Properties.Update(propertyEntity);
            await _db.SaveAsync();
            return model;
        }
    }
}
