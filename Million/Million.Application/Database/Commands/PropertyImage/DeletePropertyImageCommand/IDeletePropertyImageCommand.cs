namespace Million.Application.Database.Commands.PropertyImage.DeletePropertyImageCommand
{
    public interface IDeletePropertyImageCommand
    {
        /// <summary>
        /// This method is used to delete property image from database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Execute(DeletePropertyImageModel model);
    }
}
