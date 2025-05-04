using Million.Domain.Entities.Address;

namespace Million.Application.Database.Queries.GetAddressQuery
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="db"></param>
    public class GetAddressQuery(IDataBaseService db) : IGetAddressQuery
    {
        /// <summary>
        /// GLOBALS
        /// </summary>
        private readonly IDataBaseService _db = db;

        /// <summary>
        /// This method is used to get an address by id from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GetAddressModel?> Execute(Guid id)
        {
            AddressEntity? entity = await _db.Addresses.FindAsync(id);
            if (entity == null) return null;

            return new GetAddressModel
            {
                IdAddress = entity.IdAddress,
                Street = entity.Street,
                City = entity.City,
                State = entity.State,
                ZipCode = entity.ZipCode,
                Country = entity.Country
            };
        }
    }

}
