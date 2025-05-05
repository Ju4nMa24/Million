using System.Text.Json.Serialization;

namespace Million.Application.Database.Commands.Address.CreateAddressCommand
{
    public class CreateAddressModel
    {
        [JsonIgnore]
        public Guid IdAddress { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }
        [JsonIgnore]
        public DateTime CreationDate { get; set; }
        [JsonIgnore]
        public DateTime ModificationDate { get; set; }
    }
}
