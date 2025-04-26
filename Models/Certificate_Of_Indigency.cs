using System.ComponentModel.DataAnnotations;

namespace SocialWelfarre.Models
{
    public class Certificate_Of_Indigency
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public int Age { get; set; }
        public Barangay1? Barangay { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Brgy_Cert { get; set; }
        public string Valid_ID { get; set; }
        public Reason1? Reason { get; set; }
        public ActiveStatus1? Status { get; set; }
    }
    public enum Barangay1
    {
        [Display(Name = "Barangay 1")]
        Barangay1,
        [Display(Name = "Barangay 2")]
        Barangay2,
        [Display(Name = "Barangay 3")]
        Barangay3,
        [Display(Name = "Barangay 4")]
        Barangay4,
        [Display(Name = "Barangay 5")]
        Barangay5,
        [Display(Name = "Barangay 6")]
        Barangay6,
        [Display(Name = "Barangay 7")]
        Barangay7,
        [Display(Name = "Barangay 8")]
        Barangay8,
        [Display(Name = "Barangay 9")]
        Barangay9,
        [Display(Name = "Barangay 10")]
        Barangay10
    }

    public enum Reason1
    {
        [Display(Name = "Hunger")]
        Hunger,
        [Display(Name = "Poverty")]
        Poverty,
        [Display(Name = "Unemployment")]
        Unemployment,
        [Display(Name = "Health Issues")]
        HealthIssues,
        [Display(Name = "Other Reasons")]
        Other
    }

    public enum ActiveStatus1
    {
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Approved")]
        Approved,
        [Display(Name = "Denied")]
        Denied
    }
}

