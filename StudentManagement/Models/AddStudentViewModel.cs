using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class AddStudentViewModel
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string? StudentName { get; set; }
        [Required]
        public DateTime? Dob { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public double? Score { get; set; }
        [Required]
        public int? ClassID { get; set; }
    }
}