namespace Million.Application.Database.Commands.PropertyTrace.CreatePropertyTraceCommand
{
    public class CreatePropertyTraceModel
    {
        public required string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }

        public Guid IdProperty { get; set; }
        public DateTime DateSale { get; set; }
    }

}
