using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCSharp.Models;

/// <summary>
/// Extended information available to a use about themselves.
/// <see cref="SplitwiseUser"/>
/// </summary>
public class SplitwiseUserSelf : SplitwiseUser
{
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
