namespace Million.Application.Database.Commands.PropertyTrace.UpdatePropertyTraceCommand
{
    public class UpdatePropertyTraceModel
    {
        public Guid IdPropertyTrace { get; set; }
        public required string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public DateTime DateSale { get; set; }
    }

}
