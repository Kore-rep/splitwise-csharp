using SplitwiseDotnetSDK.Models;

namespace SplitwiseDotnetSDK.Requests
{
    public class CreateExpenseRequest : SplitwiseExpenseBase
    {
        public bool SplitEqually { get; set; }
    }
}
