namespace SplitwiseDotnetSDK.Models;

public class SplitwiseExpense : SplitwiseExpenseBase
{
    public int Id { get; set; }
    public int FriendshipId { get; set; }
    public int ExpenseBundleId { get; set; }
    public bool Repeats { get; set; }
    public bool EmailReminder { get; set; }
    public string EmailReminderInAdvance { get; set; } = null;
    public string NextRepeat { get; set; }
    public int CommentsCount { get; set; }
    public bool Payment { get; set; }
    public bool TransactionConfirmed { get; set; }
    public SplitwisePayment[] Repayments { get; set; }
    public DateTime CreatedAt { get; set; }
    public SplitwiseUser CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public SplitwiseUser UpdatedBy { get; set; }
    public DateTime DeletedAt { get; set; }
    public SplitwiseUser DeletedBy { get; set; }
    public SplitwiseExpenseCategory Category { get; set; }
    public SplitwiseReceipt Receipt { get; set; }
    public SplitwiseExpenseUser[] Users { get; set; }
    public SplitwiseComment[] Comments { get; set; }
    
}


/// <summary>
/// Represents a picture of the recipt. Usually a link to Splitwise S3 Bucket
/// </summary>
public class SplitwiseReceipt
{
    public string Large { get; set; }
    public string Original { get; set;}
}
