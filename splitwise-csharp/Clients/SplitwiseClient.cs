using System.Text.Json;
using SplitwiseCSharp.Interfaces;
using SplitwiseCSharp.Models;
using SplitwiseCSharp.Responses;
using SplitwiseCSharp.Utils;

namespace SplitwiseCSharp.Clients;

public class SplitwiseClient : ISplitwiseClient
{

    private readonly HttpClient Client;

    public SplitwiseClient(string clientId, string clientSecret)
    {
        Client = new HttpClient(new AuthenticatedHttpClientHandler(clientId, clientSecret));
    }

    public async Task<GetCurrentUserResponse> GetCurrentUser() 
    {
        var getUserReponse = await Client.GetAsync(SplitwiseConstants.GET_CURRENT_USER_URL);
        var getUserResponseJson = getUserReponse.Content;
        if (getUserResponseJson != null) 
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<GetCurrentUserResponse>(await getUserResponseJson.ReadAsStringAsync());
        }
        return null;
    }
}
