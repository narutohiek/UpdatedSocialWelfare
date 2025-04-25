namespace SocialWelfarre.Models
{
    public class ApplicationFoodPacks
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {MiddleName} {LastName}";
        public int Age { get; set; }
        public int BrgyID { get; set; }
        public PoblacionBrgy barangay { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public int ReasonID { get; set; }
        public Reason Reason { get; set; }
        public ApplicationStatus Status { get; set; }

    }

    public enum ApplicationStatus
    {
        Pending,
        Approved,
        Rejected
    }
    public enum Reason
    {
        LostJob,
        NoIncome,
        Medical,
        Other
    }
    public enum PoblacionBrgy
    {
        Poblacion1,
        Poblacion2,
        Poblacion3,
        Poblacion4,
        Poblacion5,
        Poblacion6,
        Poblacion7,
        Poblacion8,
        Poblacion9,
        Poblacion10
    }
}
