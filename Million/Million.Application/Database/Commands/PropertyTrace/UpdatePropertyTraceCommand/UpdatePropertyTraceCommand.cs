using AutoMapper;
using Million.Domain.Entities.PropertyTrace;

namespace Million.Application.Database.Commands.PropertyTrace.UpdatePropertyTraceCommand
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public class UpdatePropertyTraceCommand(IDataBaseService db, IMapper mapper) : IUpdatePropertyTraceCommand
    {
        /// <summary>
        /// GLOBALS.
        /// </summary>
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// This method is used to update property trace info.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<UpdatePropertyTraceModel?> Execute(UpdatePropertyTraceModel model)
        {
            PropertyTraceEntity? propertyTraceEntity = await _db.PropertyTraces.FindAsync(model.IdPropertyTrace);
            if (propertyTraceEntity == null) return null;

            _mapper.Map(model, propertyTraceEntity);
            //propertyTraceEntity.ModifiedAt = DateTime.UtcNow;
            _db.PropertyTraces.Update(propertyTraceEntity);
            await _db.SaveAsync();
            return model;
        }
    }
}
