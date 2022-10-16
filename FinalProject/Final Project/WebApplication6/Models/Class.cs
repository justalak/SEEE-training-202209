using System.ComponentModel.DataAnnotations;


namespace WebApplication6.Models
{
    public class Class 
    {
        [Key]
        public int IdClass { get; set; }
        [Required]
        public string NameClass { get; set; }
        public int? IdTeacher { get; set; }
    }
}
