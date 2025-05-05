using Million.Domain.Entities.OwnerContact;

namespace Million.Application.Database.Queries.GetOwnerContactByIdQuery
{
    public interface IGetOwnerContactByIdQuery
    {
        /// <summary>
        /// This method is used to get the owner contact by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OwnerContactEntity?> Execute(Guid id);
    }
}
