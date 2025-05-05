namespace Million.Application.Database.Commands.PropertyTrace.UpdatePropertyTraceCommand
{
    public interface IUpdatePropertyTraceCommand
    {

        /// <summary>
        /// This method is used to update property trace info.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<UpdatePropertyTraceModel?> Execute(UpdatePropertyTraceModel model);
    }
}
