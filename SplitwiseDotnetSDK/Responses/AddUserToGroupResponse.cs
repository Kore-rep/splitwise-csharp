using SplitwiseDotnetSDK.Models;

namespace SplitwiseDotnetSDK.Responses;

public class AddUserToGroupResponse : CreateResponseBase
{
    public bool Success { get; set; }
    public SplitwiseUser User { get; set; }
}
