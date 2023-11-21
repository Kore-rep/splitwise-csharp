using SplitwiseDotnetSDK.Models;

namespace SplitwiseDotnetSDK.Interfaces;

public interface ISplitwiseUser
{
    int Id { get; set; }
    string? FirstName { get; set; }
    string? LastName { get; set; }
    string? Email { get; set; }
    string? RegistrationStatus { get; set; }
    SplitwisePicture? Picture { get; set; }
}
