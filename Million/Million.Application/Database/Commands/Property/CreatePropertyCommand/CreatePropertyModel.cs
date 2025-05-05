using System.Text.Json.Serialization;

namespace Million.Application.Database.Commands.Property.CreatePropertyCommand
{
    public class CreatePropertyModel
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string CodeInternal { get; set; }
        public int Year { get; set; }
        public required string Status { get; set; }

        public Guid IdOwner { get; set; }
        [JsonIgnore]
        public Guid IdAddress { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }

}
