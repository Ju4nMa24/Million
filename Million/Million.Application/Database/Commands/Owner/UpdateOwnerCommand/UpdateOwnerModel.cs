using Million.Application.Database.Commands.Address.UpdateAddressCommand;
using Million.Application.Database.Commands.OwnerContact.UpdateOwnerContactCommand;
using System.Text.Json.Serialization;

namespace Million.Application.Database.Commands.Owner.UpdateOwnerCommand
{
    public class UpdateOwnerModel
    {
        [JsonIgnore]
        public Guid IdOwner { get; set; }
        public required string Name { get; set; }
        public required string OldEmail { get; set; }
        public DateTime Birthday { get; set; }
        public string? Photo { get; set; }
        [JsonIgnore]
        public Guid IdAddress { get; set; }

        public UpdateAddressModel? Address { get; set; } = null!;
        public UpdateOwnerContactModel? Contact { get; set; } = null!;
    }
}
