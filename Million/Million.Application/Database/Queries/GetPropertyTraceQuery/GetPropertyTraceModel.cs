namespace Million.Application.Database.Queries.GetPropertyTraceQuery
{
    public class GetPropertyTraceModel
    {
        public Guid IdPropertyTrace { get; set; }
        public required string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public DateTime DateSale { get; set; }
    }
}
