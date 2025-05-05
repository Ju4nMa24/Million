namespace Million.Application.Database.Commands.Property.UpdatePropertyCommand
{
    public interface IUpdatePropertyCommand
    {
        /// <summary>
        /// Update property command.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UpdatePropertyModel?> Execute(UpdatePropertyModel model);
    }
}
