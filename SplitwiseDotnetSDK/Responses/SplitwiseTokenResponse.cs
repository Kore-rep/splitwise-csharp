using System.Text.Json.Serialization;

namespace SplitwiseDotnetSDK.Responses;

/// <summary>
/// A wrapper class for the response from generating an auth token from Splitwise.
/// </summary>
internal class SplitwiseTokenResponse
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }
    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }
}
