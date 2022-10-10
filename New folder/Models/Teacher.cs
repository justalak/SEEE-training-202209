using System.ComponentModel.DataAnnotations;

namespace MySchool.Models
{
    public class Teacher
    {
        [Key]
        public int IdTeacher { get; set; }
        [Required]
        public string NameTeacher { get; set; }
    }
}
