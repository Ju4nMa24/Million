using System.Text.Json.Serialization;

namespace Million.Application.Database.Commands.OwnerContact.CreateOwnerContactCommand
{
    public class CreateOwnerContactModel
    {
        [JsonIgnore]
        public Guid IdOwner { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Type { get; set; }
    }
}
