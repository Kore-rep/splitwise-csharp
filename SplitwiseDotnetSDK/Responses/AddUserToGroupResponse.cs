using SplitwiseDotnetSDK.Models;

namespace SplitwiseDotnetSDK.Responses;

public class AddUserToGroupResponse
{
    public bool Success { get; set; }
    public SplitwiseUser User { get; set; }
    public string[] Errors { get; set; }
}
