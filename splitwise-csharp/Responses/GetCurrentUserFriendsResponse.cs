using SplitwiseCSharp.Models;

namespace SplitwiseCSharp.Responses;

public class GetCurrentUserFriendsResponse
{
    public SplitwiseFriend[] Friends { get; set; }
}
