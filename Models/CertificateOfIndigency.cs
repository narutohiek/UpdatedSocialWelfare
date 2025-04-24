namespace SocialWelfarre.Models
{
    public class CertificateOfIndigency
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string FullName => $"{First_Name} {Middle_Name} {Last_Name}";
        public int BarangayId { get; set; }
        public Barangay Barangay { get; set; }
        public DateTime Date_Issued { get; set; }
        public string Validate { get; set; }
    }
}
