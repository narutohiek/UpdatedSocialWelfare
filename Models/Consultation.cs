namespace SocialWelfarre.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string FullName => $"{First_Name} {Middle_Name} {Last_Name}";
        public int BeneficiaryId { get; set; }
        public DateOnly Consulatation_Date { get; set; }
        public TimeOnly Consultation_Time { get; set; }
        public string consultation_status { get; set; }
    }
}
