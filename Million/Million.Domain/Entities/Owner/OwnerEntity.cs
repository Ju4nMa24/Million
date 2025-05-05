using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Million.Domain.Entities.Address;
using Million.Domain.Entities.OwnerContact;
using Million.Domain.Entities.Property;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Million.Domain.Entities.Owner
{
    public class OwnerEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdOwner { get; set; }
        public required string Name { get; set; }
        public DateTime Birthday { get; set; }
        public required string Photo { get; set; }

        public Guid IdAddress { get; set; }
        public required AddressEntity Address { get; set; }

        public ICollection<PropertyEntity>? Properties { get; set; }
        public ICollection<OwnerContactEntity>? Contacts { get; set; }
    }
}
