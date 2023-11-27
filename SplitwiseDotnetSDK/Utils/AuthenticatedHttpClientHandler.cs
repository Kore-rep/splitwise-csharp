
using System.Security.Authentication;
using System.Text.Json;

namespace SplitwiseDotnetSDK.Utils;
/// <summary>
/// A customer version of <see cref="HttpClientHandler"/> that ensures requests are Authenticated before sending.
/// </summary>
internal class AuthenticatedHttpClientHandler : HttpClientHandler
{
    private string? AccessToken = null;
    private readonly string ClientId;
    private readonly string ClientSecret;
    private readonly HttpClient _httpClient;

    public AuthenticatedHttpClientHandler(string clientId, string clientSecret, HttpClient client)
    {
        ClientId = clientId;
        ClientSecret = clientSecret;
        _httpClient = client;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            AccessToken ??= (await OAuthUtil.GetAccessTokenAsync(_httpClient, ClientId, ClientSecret)).AccessToken;
        } catch (HttpRequestException ex)
        {
            throw new AuthenticationException($"Unable to retrieve new Access Token: {ex.Message}");
        } catch (JsonException ex)
        {
            throw new AuthenticationException($"Unable to deserialize new Access Token: {ex.Message}");
        } catch (Exception ex)
        {
            throw new AuthenticationException($"Unable to get Access Token: {ex.Message}");
        }
        
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
        var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        return response;
    }
}
