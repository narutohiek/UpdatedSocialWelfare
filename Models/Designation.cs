using System.ComponentModel.DataAnnotations;

namespace SocialWelfarre.Models
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }
        public string Designations { get; set; }
    }
}
