using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Million.Domain.Entities.Owner;
using Million.Domain.Entities.Property;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Million.Domain.Entities.Address
{
    public class AddressEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdAddress { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }

        public ICollection<OwnerEntity>? Owners { get; set; }
        public ICollection<PropertyEntity>? Properties { get; set; }
    }
}
