namespace SplitwiseDotnetSDK.Models
{
    abstract public class SplitwiseExpenseBase
    {
        public float Cost { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public string RepeatInterval { get; set; }
        public string CurrencyCode { get; set; }
        public int CategoryId { get; set; }
        public int GroupId { get; set; }
    }
}
