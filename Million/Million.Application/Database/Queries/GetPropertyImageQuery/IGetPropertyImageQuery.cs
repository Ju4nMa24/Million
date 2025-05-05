namespace Million.Application.Database.Queries.GetPropertyImageQuery
{
    public interface IGetPropertyImageQuery
    {
        /// <summary>
        /// This method is used to get a property image by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetPropertyImageModel?> Execute(Guid id);
    }
}
