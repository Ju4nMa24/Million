namespace Million.Application.Database.Commands.OwnerContact.UpdateOwnerContactCommand
{
    public class UpdateOwnerContactModel
    {
        public Guid IdContact { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Type { get; set; }
    }

}
