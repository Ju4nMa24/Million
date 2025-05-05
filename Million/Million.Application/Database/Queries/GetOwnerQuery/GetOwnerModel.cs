namespace Million.Application.Database.Queries.GetOwnerQuery
{
    public class GetOwnerModel
    {
        public Guid IdOwner { get; set; }
        public required string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string? Photo { get; set; }
        public Guid IdAddress { get; set; }
    }
}
