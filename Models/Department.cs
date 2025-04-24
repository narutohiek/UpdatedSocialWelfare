using System.ComponentModel.DataAnnotations;

namespace SocialWelfarre.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Departments { get; set; }
    }
}
