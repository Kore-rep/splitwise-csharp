
using SplitwiseDotnetSDK.Models;

namespace SplitwiseDotnetSDK.Responses;

/// <summary>
/// A wrapper class for the Update User call's response.
/// </summary>
public class UpdateUserResponse
{
    public SplitwiseUserSelf User { get; set; }
    public string[] Errors { get; set; }
}
