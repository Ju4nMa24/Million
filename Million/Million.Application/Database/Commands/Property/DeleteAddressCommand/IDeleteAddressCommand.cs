namespace Million.Application.Database.Commands.Property.DeleteAddressCommand
{
    public interface IDeleteAddressCommand
    {
        /// <summary>
        /// Delete address command.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Execute(DeleteAddressModel model);
    }
}
