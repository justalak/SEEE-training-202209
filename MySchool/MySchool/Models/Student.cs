using System;
using System.ComponentModel.DataAnnotations;

namespace MySchool.Models
{
    [Serializable]
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only allow letters")]
        public string NameStudent { get; set; }
        [StringLength(10, ErrorMessage = "Gender length can't be more than 10")]
        public string? Gender { get; set; } = "Male";
        [EmailAddress(ErrorMessage = "Must be Email")]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Phone(ErrorMessage = "Must be phone number")]
        public string? PhoneNumber { get; set; }
        [Range(0, 10, ErrorMessage = "Score must in range 0 to 10")]
        public int? Score { get; set; }
        public int? IdClass { get; set; }
    }
}
