namespace Million.Application.Database.Commands.PropertyImage.CreatePropertyImageCommand
{
    public interface ICreatePropertyImageCommand
    {
        /// <summary>
        /// This method is used to create a new property image.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CreatePropertyImageModel?> Execute(CreatePropertyImageModel model);
    }
}
