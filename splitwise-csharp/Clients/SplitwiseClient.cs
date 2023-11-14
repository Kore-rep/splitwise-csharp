using System.Text.Json;
using SplitwiseCSharp.Interfaces;
using SplitwiseCSharp.Models;
using SplitwiseCSharp.Responses;
using SplitwiseCSharp.Utils;

namespace SplitwiseCSharp.Clients;

/// <summary>
/// Class SplitwiseClient provides methods to interact with the splitwise API https://dev.splitwise.com/#section/Introduction
/// It makes use of the OAuth 2.0 Client Credentials flow
/// </summary>
public class SplitwiseClient : ISplitwiseClient
{

    private readonly HttpClient Client;

    /// <summary>
    /// The constructor for a Splitwise Client.
    /// </summary>
    /// <param name="clientId">Consumer Key from https://secure.splitwise.com</param>
    /// <param name="clientSecret">Consumber Secret from https://secure.splitwise.com</param>
    public SplitwiseClient(string clientId, string clientSecret)
    {
        Client = new HttpClient(new AuthenticatedHttpClientHandler(clientId, clientSecret));
    }

    /// <summary>
    /// Fetches the current user given the client ID and secret.
    /// </summary>
    /// <exception cref="HttpRequestException">
    /// Thrown when the Get Request fails.
    /// </exception>
    /// <returns>
    /// A <see cref="GetCurrentUserResponse"/> or <c>null</c>.
    /// </returns>
    public async Task<GetCurrentUserResponse> GetCurrentUser() 
    {
        var getUserReponse = await Client.GetAsync(SplitwiseConstants.GET_CURRENT_USER_URL);
        getUserReponse.EnsureSuccessStatusCode();
        var getUserResponseJson = getUserReponse.Content;
        if (getUserResponseJson != null) 
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<GetCurrentUserResponse>(await getUserResponseJson.ReadAsStringAsync());
        }
        return null;
    }

    /// <summary>
    /// Fetches information about a particular user.
    /// </summary>
    /// <param name="userId">Id of the user to fetch info about</param>
    /// <returns>A <see cref="GetUserByIdResponse"/> or <c>null</c></returns>
    public async Task<GetUserByIdResponse> GetUser(int userId)
    {
        var getUserReponse = await Client.GetAsync(SplitwiseConstants.GET_CURRENT_USER_URL + $"/{userId}");
        var getUserResponseJson = getUserReponse.Content;
        getUserReponse.EnsureSuccessStatusCode();
        if (getUserResponseJson != null)
        {
            return JsonSerializerExtensions.DeserializeFromSnakeCase<GetUserByIdResponse>(await getUserResponseJson.ReadAsStringAsync());
        }
        return null;
    }


}
