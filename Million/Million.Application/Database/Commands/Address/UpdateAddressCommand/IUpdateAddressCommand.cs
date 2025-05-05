namespace Million.Application.Database.Commands.Address.UpdateAddressCommand
{
    public interface IUpdateAddressCommand
    {
        /// <summary>
        /// This method updates an address in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UpdateAddressModel?> Execute(UpdateAddressModel model);
    }
}
