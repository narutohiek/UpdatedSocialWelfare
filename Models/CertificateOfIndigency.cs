namespace SocialWelfarre.Models
{
    public class CertificateOfIndigency
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public int Age { get; set; }
        public PoblacionBrgy barangay { get; set; }

    }
}
