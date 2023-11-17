namespace SplitwiseCSharp.Requests;

/// <summary>
/// A request body to update a user. Null values will not be sent in the request.
/// </summary>
public class UpdateUserRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Locale { get; set; }
    public string? DefaultCurrency { get; set; }
}
