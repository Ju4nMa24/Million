namespace Million.Application.Database.Queries.GetPropertyQuery
{
    public class GetPropertyModel
    {
        public Guid IdProperty { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string CodeInternal { get; set; }
        public int Year { get; set; }
        public required string Status { get; set; }

        public Guid IdOwner { get; set; }
        public Guid IdAddress { get; set; }
    }
}
