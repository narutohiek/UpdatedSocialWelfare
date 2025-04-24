namespace SocialWelfarre.Models
{
    public class Beneficiary 
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string FullName => $"{First_Name} {Middle_Name} {Last_Name}";
        public int ID_Number { get; set; }
        public DateOnly Date_Of_Birth { get; set; }
        public int Contact_Number { get; set; }
        public string Address { get; set; }
        public int BarangayId { get; set; }
        public Barangay Barangay { get; set; }
        public string Eligibility_Status { get; set; }
        public int BeneficiaryTypeId { get; set; }
        public BeneficiaryType BeneficiaryType { get; set; }
    }
}
