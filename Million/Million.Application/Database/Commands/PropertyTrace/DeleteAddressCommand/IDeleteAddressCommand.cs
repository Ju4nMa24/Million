namespace Million.Application.Database.Commands.PropertyTrace.DeleteAddressCommand
{
    public interface IDeleteAddressCommand
    {
        /// <summary>
        /// This method is used to delete address from database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Execute(DeleteAddressModel model);
    }
}
