namespace Million.Application.Database.Commands.Owner.DeleteOwnerCommand
{
    public interface IDeleteOwnerCommand
    {
        /// <summary>
        /// This method is used to delete the owner info in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Execute(DeleteOwnerModel model);
    }
}
