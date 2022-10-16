using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class Teacher
    {
        [Key]
        public int IdTeacher { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only allow letters")]
        public string NameTeacher { get; set; }
    }

}
