namespace Million.Application.Database.Queries.GetPropertyImageQuery
{
    public class GetPropertyImageModel
    {
        public Guid IdPropertyImage { get; set; }
        public required string File { get; set; }
        public bool Enabled { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
