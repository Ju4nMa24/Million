using Million.Application.Database.Commands.Address.CreateAddressCommand;
using Million.Application.Database.Commands.OwnerContact.CreateOwnerContactCommand;
using System.Text.Json.Serialization;

namespace Million.Application.Database.Commands.Owner.CreateOwnerCommand
{
    public class CreateOwnerModel
    {
        [JsonIgnore]
        public Guid IdOwner { get; set; }
        public required string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string? Photo { get; set; }
        [JsonIgnore]
        public Guid IdAddress { get; set; }
        public required CreateAddressModel Address { get; set; }
        public required CreateOwnerContactModel Contact { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }
        [JsonIgnore]
        public DateTime ModificationDate { get; set; }
    }
}
