using System.ComponentModel.DataAnnotations;

namespace MySchool.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        [Required]
        public string NameStudent { get; set; }
        [StringLength(10, ErrorMessage = "Gender length can't be more than 10")]
        public string? Gender { get; set; }
        [EmailAddress(ErrorMessage = "Must be Email")]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "Must be phone number")]
        public string? PhoneNumber { get; set; }
        [Range(0, 10, ErrorMessage = "Score must in range 0 to 10")]
        public int? Score { get; set; }
        [Range(0, 10, ErrorMessage = "IdClass must in range 0 to 10")]
        public int? IdClass { get; set; }
    }
}
