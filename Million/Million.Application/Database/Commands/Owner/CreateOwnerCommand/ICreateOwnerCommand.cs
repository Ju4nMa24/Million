namespace Million.Application.Database.Commands.Owner.CreateOwnerCommand
{
    public interface ICreateOwnerCommand
    {
        /// <summary>
        /// Creates a new owner in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CreateOwnerModel?> Execute(CreateOwnerModel model);
    }
}
