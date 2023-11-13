namespace SplitwiseCSharp.Requests;
public class GetAuthCodeRequest
{
    public required string grant_type { get; set; }
    public required string code { get; set; }
    public required string client_id { get; set; }
    public required string client_secret { get; set; }
}