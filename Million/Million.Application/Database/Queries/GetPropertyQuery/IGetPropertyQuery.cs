namespace Million.Application.Database.Queries.GetPropertyQuery
{
    public interface IGetPropertyQuery
    {
        /// <summary>
        /// This method is used to get a property by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetPropertyModel?> Execute(Guid id);
    }
}
