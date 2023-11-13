
namespace SplitwiseCSharp.Utils;

internal class AuthenticatedHttpClientHandler : HttpClientHandler
{
    private string? AccessToken = null;
    private readonly string ClientId;
    private readonly string ClientSecret;

    public AuthenticatedHttpClientHandler(string clientId, string clientSecret)
    {
        ClientId = clientId;
        ClientSecret = clientSecret;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Authenticating Request...");
        AccessToken ??= (await OAuthUtil.GetAccessTokenAsync(ClientId, ClientSecret)).AccessToken;
        
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
        Console.WriteLine($"Sending Request... {request}");
        var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

        return response;
    }
}
