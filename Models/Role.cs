using System.ComponentModel.DataAnnotations;

namespace SocialWelfarre.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Roles { get; set; }
    }
}
