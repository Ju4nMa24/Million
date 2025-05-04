namespace Million.Application.Database.Queries.GetAddressQuery
{
    public class GetAddressModel
    {
        public Guid IdAddress { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }
    }
}
