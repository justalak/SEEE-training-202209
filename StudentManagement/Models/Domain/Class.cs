using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models.Domain
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        public string? ClassName { get; set; }

        public int? TeacherID { get; set; }
    }
}
