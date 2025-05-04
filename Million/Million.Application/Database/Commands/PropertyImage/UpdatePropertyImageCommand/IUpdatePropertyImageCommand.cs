namespace Million.Application.Database.Commands.PropertyImage.UpdatePropertyImageCommand
{
    internal interface IUpdatePropertyImageCommand
    {
        /// <summary>
        /// This method is used to update property image.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UpdatePropertyImageModel?> Execute(UpdatePropertyImageModel model);
    }
}
