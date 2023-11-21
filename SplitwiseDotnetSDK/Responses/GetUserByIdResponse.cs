using SplitwiseDotnetSDK.Models;

namespace SplitwiseDotnetSDK.Responses;

/// <summary>
/// A wrapper for a response from the GetUser endpoint.
/// </summary>
public class GetUserByIdResponse
{
    public SplitwiseUser User { get; set; }
}
