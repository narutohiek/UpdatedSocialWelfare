namespace SocialWelfarre.Models
{
    public class AuditLog
    {
            public int Id { get; set; }
            public string UserEmail { get; set; } // from IdentityUser Email
            public string FullName { get; set; } // from IdentityUser FullName
            public string ActionTaken { get; set; }
            public string ControllerName { get; set; }
            public string ActionName { get; set; }
            public string Details { get; set; }
            public DateTime Timestamp { get; set; }
        }
    }

