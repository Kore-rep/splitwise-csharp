using SplitwiseDotnetSDK.Models;

namespace SplitwiseDotnetSDK.Responses;

public class CreateExpenseResponse : CreateResponseBase
{
    public SplitwiseExpense Expense { get; set; }
}
