namespace Million.Application.Database.Commands.Owner.CreateOwnerCommand
{
    public class CreateOwnerModel
    {
        public required string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string? Photo { get; set; }
        public Guid IdAddress { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
