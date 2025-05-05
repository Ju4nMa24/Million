namespace Million.Application.Database.Commands.PropertyTrace.CreatePropertyTraceCommand
{
    public interface ICreatePropertyTraceCommand
    {
        /// <summary>
        /// This method is used to create a property trace.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CreatePropertyTraceModel?> Execute(CreatePropertyTraceModel model);
    }
}
