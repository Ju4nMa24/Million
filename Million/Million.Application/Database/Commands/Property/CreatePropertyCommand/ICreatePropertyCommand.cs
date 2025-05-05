namespace Million.Application.Database.Commands.Property.CreatePropertyCommand
{
    public interface ICreatePropertyCommand
    {
        /// <summary>
        /// Creates a new property.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CreatePropertyModel?> Execute(CreatePropertyModel model);
    }
}
