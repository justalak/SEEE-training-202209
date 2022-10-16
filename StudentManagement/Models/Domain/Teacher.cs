using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models.Domain
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string? TeacherName { get; set; }
    }
}
