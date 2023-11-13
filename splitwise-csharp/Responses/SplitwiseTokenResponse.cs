using System.Text.Json.Serialization;

namespace SplitwiseCSharp.Responses;

public class SplitwiseTokenResponse
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }
    [JsonPropertyName("token_type")]
    public string? TokenType { get; set; }
}
