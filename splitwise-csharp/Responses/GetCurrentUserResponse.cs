using SplitwiseCSharp.Models;

namespace SplitwiseCSharp.Responses;

/// <summary>
/// A response wrapper for the GetCurrentUser endpoint
/// </summary>
public class GetCurrentUserResponse
{
    public SplitwiseUserSelf User { get; set; }
}
