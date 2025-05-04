using Million.Domain.Entities.Property;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Million.Domain.Entities.PropertyTrace
{
    public class PropertyTraceEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdPropertyTrace { get; set; }
        public DateTime DateSale { get; set; }
        public required string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }

        public Guid IdProperty { get; set; }
        public PropertyEntity? Property { get; set; }
    }
}
