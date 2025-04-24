using System.ComponentModel.DataAnnotations;

namespace SocialWelfarre.Models
{
    public class BeneficiaryType
    {
        [Key]
        public int Id { get; set; }
        public string BeneficiaryTypes { get; set; }
    }
}
