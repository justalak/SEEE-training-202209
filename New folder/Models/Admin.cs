using System.ComponentModel.DataAnnotations;

namespace MySchool.Models
{
    public class Admin
    {
        [Key]
        public int IdAdmin { get; set; }
        public string? NameAdmin { get; set; }
        [EmailAddress(ErrorMessage = "Must be Email")]
        public string? EmailAdmin { get; set; }
        public string? PassAdmin { get; set; }
    }
}
