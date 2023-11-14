using SplitwiseCSharp.Interfaces;

namespace SplitwiseCSharp.Models;

/// <summary>
/// Base information available about all users through ID lookup.
/// </summary>
public class SplitwiseUser : ISplitwiseUser
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set;}
    public string? Email { get; set; }
    public string? RegistrationStatus { get; set; }
    public SplitwisePicture? Picture { get; set; }
}


