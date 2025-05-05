namespace Million.Application.Database.Commands.PropertyImage.CreatePropertyImageCommand
{
    public class CreatePropertyImageModel
    {
        public required string File { get; set; }
        public bool Enabled { get; set; }
        public Guid IdProperty { get; set; }
        public DateTime UploadedAt { get; set; }
    }

}
