using Million.Domain.Entities.Owner;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Million.Domain.Entities.OwnerContact
{
    public class OwnerContactEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdContact { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Type { get; set; }

        public Guid IdOwner { get; set; }
        public OwnerEntity? Owner { get; set; }
    }
}
