namespace Million.Application.Database.Queries.GetAddressQuery
{
    public interface IGetAddressQuery
    {
        /// <summary>
        /// This method is used to get an address by id from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GetAddressModel?> Execute(Guid id);
    }
}
