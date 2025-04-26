using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace SocialWelfarre.Models
{
    public class FoodPackForm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string Barangay { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }

        [NotMapped] // Exclude this property from the database
        public IFormFile Picture { get; set; }

        public byte[] PictureData { get; set; } // Store the file as binary data
        public string PicturePath { get; set; } // Store the file path if needed
    }

}
