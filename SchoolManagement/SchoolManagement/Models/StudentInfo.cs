using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models.Enum;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Models
{
    public class StudentInfo
    {
        //-	Student: Id, Name, Gender, Email, PhoneNumber, Score, ClassId
        [DisplayName("Student Id")]
        [Key]
        public int StudentId { get; set; }

        [DisplayName("Student Name")]
        [Required]
        public string StudentName { get; set; }
        [DisplayName("Student Gender")]
        public StudentGender StudentGender { get; set; }
        [DisplayName("Student Email")]
        public string StudentEmail { get; set; }
        [DisplayName("Student Phone Number")]
        public string StudentPhoneNumber { get; set; }
        [DisplayName("Student Score")]
        public float StudentScore { get; set; }
        [DisplayName("Student Class Id")]
        public int ClassId { get; set; }
    }
}
