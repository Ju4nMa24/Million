namespace Million.Application.Database.Commands.PropertyImage.UpdatePropertyImageCommand
{
    public class UpdatePropertyImageModel
    {
        public Guid IdPropertyImage { get; set; }
        public required string File { get; set; }
        public bool Enabled { get; set; }
        public DateTime UploadedAt { get; set; }
    }

}
