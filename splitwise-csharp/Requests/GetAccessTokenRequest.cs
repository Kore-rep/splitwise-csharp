namespace SplitwiseCSharp.Requests;
public class GetAccessTokenRequest
{
    public required string grant_type { get; set; }
    public required string client_id { get; set; }
    public required string client_secret { get; set; }
}