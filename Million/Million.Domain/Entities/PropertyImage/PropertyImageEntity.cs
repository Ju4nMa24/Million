using Million.Domain.Entities.Property;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Million.Domain.Entities.PropertyImage
{
    public class PropertyImageEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdPropertyImage { get; set; }
        public required string File { get; set; }
        public bool Enabled { get; set; }
        public DateTime UploadedAt { get; set; }

        public Guid IdProperty { get; set; }
        public PropertyEntity? Property { get; set; }
    }
}
