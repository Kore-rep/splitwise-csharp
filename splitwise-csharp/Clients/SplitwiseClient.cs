using SplitwiseCSharp.Interfaces;
using SplitwiseCSharp.Models;
using SplitwiseCSharp.Utils;

namespace SplitwiseCSharp.Clients;

public class SplitwiseClient : ISplitwiseClient
{

    private readonly HttpClient Client;

    public SplitwiseClient(string clientId, string clientSecret)
    {
        Client = new HttpClient(new AuthenticatedHttpClientHandler(clientId, clientSecret));
    }

    public SplitwiseUser GetSplitwiseUser() 
    {
        var getUserReponse = Client.GetAsync(SplitwiseConstants.GET_CURRENT_USER_URL);

    }
}
