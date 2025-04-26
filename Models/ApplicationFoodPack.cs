using System.ComponentModel.DataAnnotations;

namespace SocialWelfarre.Models
{
    public class ApplicationFoodPack
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        [Range(1, int.MaxValue, ErrorMessage = "Number of packs must be at least 1.")]
        public int Packs { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Age must be at least 1.")]
        public int Age { get; set; }
        public Barangay? Barangay { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Brgy_Cert { get; set; }
        public string Valid_ID { get; set; }
        public Reason? Reason { get; set; }
        public ActiveStatus? Status { get; set; }
    }
    public enum Barangay
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

    public enum Reason
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

    public enum ActiveStatus
    {
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Approved")]
        Approved,
        [Display(Name = "Denied")]
        Denied
    }
}