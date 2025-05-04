using AutoMapper;
using Million.Domain.Entities.PropertyImage;

namespace Million.Application.Database.Commands.PropertyImage.CreatePropertyImageCommand
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public class CreatePropertyImageCommand(IDataBaseService db, IMapper mapper) : ICreatePropertyImageCommand
    {
        /// <summary>
        /// GLOBALS.
        /// </summary>
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// This method is used to create a new property image.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CreatePropertyImageModel?> Execute(CreatePropertyImageModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.File))
                return null;

            //model.UploadedAt = DateTime.UtcNow;

            await _db.PropertyImages.AddAsync(_mapper.Map<PropertyImageEntity>(model));
            await _db.SaveAsync();

            return model;
        }
    }

}
