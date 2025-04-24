using System.ComponentModel.DataAnnotations;

namespace SocialWelfarre.Models
{
    public class Barangay 
    {
        [Key]
        public int Id { get; set; }
        public string Barangays { get; set; }
    }
}
