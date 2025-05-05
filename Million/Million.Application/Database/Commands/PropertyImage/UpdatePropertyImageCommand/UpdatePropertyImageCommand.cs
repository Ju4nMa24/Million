using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Million.Domain.Entities.PropertyImage;

namespace Million.Application.Database.Commands.PropertyImage.UpdatePropertyImageCommand
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="db"></param>
    /// <param name="mapper"></param>
    public class UpdatePropertyImageCommand(IDataBaseService db, IMapper mapper) : IUpdatePropertyImageCommand
    {
        /// <summary>
        /// GLOBALS.
        /// </summary>
        private readonly IDataBaseService _db = db;
        private readonly IMapper _mapper = mapper;
        /// <summary>
        /// This method is used to update property image.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<UpdatePropertyImageModel?> Execute(UpdatePropertyImageModel model)
        {
            PropertyImageEntity? propertyImageEntity = await _db.PropertyImages.FirstOrDefaultAsync(p => p.IdPropertyImage == model.IdPropertyImage);
            if (propertyImageEntity == null) return null;

            _mapper.Map(model, propertyImageEntity);
            //propertyImageEntity.ModifiedAt = DateTime.UtcNow;
            _db.PropertyImages.Update(propertyImageEntity);
            await _db.SaveAsync();
            return model;
        }
    }
}
