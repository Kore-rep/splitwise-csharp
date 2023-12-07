using SplitwiseDotnetSDK.Models;

namespace SplitwiseDotnetSDK.Responses
{
    public class GetCurrentUserExpensesResponse
    {
        public SplitwiseExpense[] Expenses { get; set; }
    }
}
