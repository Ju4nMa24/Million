namespace Million.Application.Database.Commands.OwnerContact.CreateOwnerContactCommand
{
    public interface ICreateOwnerContactCommand
    {
        /// <summary>
        /// This method is used to create a new owner contact in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CreateOwnerContactModel?> Execute(CreateOwnerContactModel model);
    }
}
