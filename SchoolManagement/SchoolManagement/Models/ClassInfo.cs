using SchoolManagement.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SchoolManagement.Models
{
    public class ClassInfo
    {
        
        [Key]
        public int ClassId { get; set; }
        [Required]
        public string ClassName { get; set; }
        public int ClassQuantity { get; set; }
        public int TeacherId { get; set; }
    }
}
