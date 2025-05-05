namespace Million.Application.Database.Commands.OwnerContact.DeleteOwnerContactCommand
{
    public interface IDeleteOwnerContactCommand
    {
        /// <summary>
        /// This method is used to delete owner contact by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Execute(Guid id);
    }
}
