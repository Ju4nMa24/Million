namespace Million.Application.Database.Commands.PropertyTrace.DeleteAddressCommand
{
    public interface IDeletePropertyTraceCommand
    {
        /// <summary>
        /// Deletes a PropertyTrace by ID.
        /// </summary>
        Task<bool> Execute(Guid id);
    }
}
