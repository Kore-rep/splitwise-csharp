using SplitwiseDotnetSDK.Interfaces;

namespace SplitwiseDotnetSDK.Models;

/// <summary>
/// Base information available about all users through ID lookup.
/// </summary>
public class SplitwiseUser 
{
    public int? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set;}
    public string? Email { get; set; }
    public string? RegistrationStatus { get; set; }
    public SplitwisePicture? Picture { get; set; }
    public bool CustomPicture { get; set; }
}



