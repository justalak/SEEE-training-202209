using System;
using System.ComponentModel.DataAnnotations;

namespace MySchool.Models
{
    [Serializable]
    public class Teacher
    {
        [Key]
        public int IdTeacher { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only allow letters")]
        public string NameTeacher { get; set; }
        [EmailAddress(ErrorMessage = "Must be Email")]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
