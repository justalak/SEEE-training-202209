using SchoolManagement.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class TeacherInfo
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string TeacherName { get; set; }
        public StudentGender TeacherGender { get; set; }
        public string TeacherEmail { get; set; }
        public string TeacherPhoneNumber { get; set; }
    }
}
