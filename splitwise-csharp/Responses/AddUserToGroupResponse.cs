using SplitwiseCSharp.Models;

namespace SplitwiseCSharp.Responses;

public class AddUserToGroupResponse
{
    public bool Success { get; set; }
    public SplitwiseUser User { get; set; }
    public string[] Errors { get; set; }
}
