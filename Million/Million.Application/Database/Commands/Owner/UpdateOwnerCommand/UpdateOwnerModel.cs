namespace Million.Application.Database.Commands.Owner.UpdateOwnerCommand
{
    public class UpdateOwnerModel
    {
        public Guid IdOwner { get; set; }
        public required string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string? Photo { get; set; }
        public Guid IdAddress { get; set; }
    }
}
