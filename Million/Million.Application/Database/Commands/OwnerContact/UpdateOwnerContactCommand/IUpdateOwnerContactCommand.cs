namespace Million.Application.Database.Commands.OwnerContact.UpdateOwnerContactCommand
{
    public interface IUpdateOwnerContactCommand
    {
        /// <summary>
        /// This method is used to update the owner contact info.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UpdateOwnerContactModel?> Execute(UpdateOwnerContactModel model);
    }
}
