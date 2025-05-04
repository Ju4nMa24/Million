namespace Million.Application.Database.Commands.Address.CreateAddressCommand
{
    public class CreateAddressModel
    {
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
