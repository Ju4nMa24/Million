namespace Million.Application.Database.Commands.Address.DeleteAddressCommand
{
    public interface IDeleteAddressCommand
    {
        /// <summary>
        /// This method is used to delete an address from the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Execute(DeleteAddressModel model);
    }
}
