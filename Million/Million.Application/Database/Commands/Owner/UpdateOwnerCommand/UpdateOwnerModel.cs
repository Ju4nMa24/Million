using Million.Application.Database.Commands.Address.UpdateAddressCommand;
using Million.Application.Database.Commands.OwnerContact.UpdateOwnerContactCommand;

namespace Million.Application.Database.Commands.Owner.UpdateOwnerCommand
{
    public class UpdateOwnerModel
    {
        public Guid IdOwner { get; set; }
        public required string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string? Photo { get; set; }
        public Guid IdAddress { get; set; }

        public UpdateAddressModel? Address { get; set; } = null!;
        public UpdateOwnerContactModel? Contact { get; set; } = null!;
    }
}
