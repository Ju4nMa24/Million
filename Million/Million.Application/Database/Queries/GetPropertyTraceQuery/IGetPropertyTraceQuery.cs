namespace Million.Application.Database.Queries.GetPropertyTraceQuery
{
    public interface IGetPropertyTraceQuery
    {
        /// <summary>
        /// This method is used to get a property trace by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetPropertyTraceModel?> Execute(Guid id);
    }
}
