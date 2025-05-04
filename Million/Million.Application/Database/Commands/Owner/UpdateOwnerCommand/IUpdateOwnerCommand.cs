namespace Million.Application.Database.Commands.Owner.UpdateOwnerCommand
{
    public interface IUpdateOwnerCommand
    {
        /// <summary>
        /// This method is used to update the owner info in the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UpdateOwnerModel?> Execute(UpdateOwnerModel model);
    }
}
