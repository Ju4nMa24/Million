using AutoMapper;
using Million.Domain.Entities.PropertyTrace;

namespace Million.Application.Database.Commands.PropertyTrace.CreatePropertyTraceCommand
{
    /// <summary>
    /// Command to create a property trace.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class CreatePropertyTraceCommand(IDataBaseService db, IMapper mapper) : ICreatePropertyTraceCommand
    {
        /// <summary>
        /// GLOBALS.
        /// </summary>
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// This method is used to create a property trace.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreatePropertyTraceModel?> Execute(CreatePropertyTraceModel model)
        {
            if (model == null || model.Value <= 0 || string.IsNullOrEmpty(model.Name))
                return null;

            model.DateSale = DateTime.UtcNow;

            await _db.PropertyTraces.AddAsync(_mapper.Map<PropertyTraceEntity>(model));
            await _db.SaveAsync();

            return model;
        }
    }

}
