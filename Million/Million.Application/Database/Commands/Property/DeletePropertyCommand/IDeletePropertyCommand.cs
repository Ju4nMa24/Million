namespace Million.Application.Database.Commands.Property.DeleteAddressCommand
{
    public interface IDeletePropertyCommand
    {
        /// <summary>
        /// This method is used to delete the property from the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Execute(DeletePropertyModel model);
    }
}
