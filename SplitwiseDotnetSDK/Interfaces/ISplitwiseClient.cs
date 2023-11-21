using SplitwiseDotnetSDK.Responses;

namespace SplitwiseDotnetSDK.Interfaces;

internal interface ISplitwiseClient
{
    Task<GetCurrentUserResponse> GetCurrentUser();
}
