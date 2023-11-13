using SplitwiseCSharp.Responses;

namespace SplitwiseCSharp.Interfaces;

internal interface ISplitwiseClient
{
    Task<GetCurrentUserResponse> GetCurrentUser();
}
