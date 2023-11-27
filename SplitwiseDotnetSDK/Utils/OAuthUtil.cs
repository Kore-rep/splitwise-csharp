using System.Net;
using System.Text.Json;
using SplitwiseDotnetSDK.Responses;

namespace SplitwiseDotnetSDK.Utils;
internal class OAuthUtil
{
    public static async Task<SplitwiseTokenResponse> GetAccessTokenAsync(HttpClient client, string clientId, string clientSecret)
    {
        if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(clientSecret))
        {
            throw new Exception("Client ID and Secret must not be null.");
        }
        var requestUri = string.Concat(
                    SplitwiseConstants.BASE_URL,
                    SplitwiseConstants.TOKEN_URL,
                    $"?grant_type={SplitwiseConstants.GRANT_TYPE}&client_id={clientId}&client_secret={clientSecret}"
                );
        var accessTokenResponse = await client.PostAsync(requestUri, null);
        var accessTokenReponseContentJson = await accessTokenResponse.Content.ReadAsStringAsync();
        if (accessTokenResponse.StatusCode != HttpStatusCode.OK)
        {
            throw new HttpRequestException(accessTokenReponseContentJson);
        }

        var accessTokenReponseContent = JsonSerializer.Deserialize<SplitwiseTokenResponse>(accessTokenReponseContentJson);
        return accessTokenReponseContent ?? throw new Exception("Got empty response.");
    }
}