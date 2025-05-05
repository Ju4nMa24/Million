using Million.Domain.Entities.Address;
using Million.Domain.Entities.Owner;
using Million.Domain.Entities.PropertyImage;
using Million.Domain.Entities.PropertyTrace;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Million.Domain.Entities.Property
{
    public class PropertyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdProperty { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string CodeInternal { get; set; }
        public int Year { get; set; }
        public required string Status { get; set; }

        public Guid? IdOwner { get; set; }
        public OwnerEntity? Owner { get; set; }

        public Guid IdAddress { get; set; }
        public AddressEntity? Address { get; set; }

        public ICollection<PropertyImageEntity>? Images { get; set; }
        public ICollection<PropertyTraceEntity>? Traces { get; set; }
    }
}
