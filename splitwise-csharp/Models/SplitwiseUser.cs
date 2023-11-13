using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseCSharp.Models
{
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

    }

    public class SplitwiseNotificationSettings
    {
    }
}
