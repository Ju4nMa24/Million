namespace Million.Application.Database.Commands.Address.CreateAddressCommand
{
    public interface ICreateAddressCommand
    {
        /// <summary>
        /// This method is used to create a new address in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CreateAddressModel?> Execute(CreateAddressModel model);
    }
}
