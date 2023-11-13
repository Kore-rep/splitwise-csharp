namespace SplitwiseCSharp.Models;

public class SplitwiseUser
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set;}
    public string? Email { get; set; }
    public string? RegistrationStatus { get; set; }
    public SplitwisePicture? Picture { get; set; }
    public DateTime NotificationsRead { get; set; }
    public int NotificationsCount { get; set; }
    public SplitwiseNotificationSettings? Notifications { get; set; }
    public string? DefaultCurrency { get; set; }
    public string? Locale { get; set; }
    public string CountryCode { get; set; }
    public string DateFormat { get; set; }
    public DateTime ForceRefreshAt { get; set; }
    public bool CustomPicture { get; set; }
    public int DefaultGroupId { get; set; }

}

public class SplitwiseNotificationSettings
{
}
