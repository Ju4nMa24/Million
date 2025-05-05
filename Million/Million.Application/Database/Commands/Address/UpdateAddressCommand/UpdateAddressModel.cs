namespace Million.Application.Database.Commands.Address.UpdateAddressCommand
{
    public class UpdateAddressModel
    {
        public Guid IdAddress { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }
    }
}
