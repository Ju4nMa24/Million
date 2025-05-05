namespace Million.Application.Database.Queries.GetOwnerQuery
{
    public interface IGetOwnerQuery
    {
        /// <summary>
        /// This method is used to get an owner by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetOwnerModel?> Execute(Guid id);
    }
}
