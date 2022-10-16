
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public abstract class User
    {

        [Required]
        public string UserName { get; set; }
       
        public string Password { get; set; }

        public string? UserRole { get; set; } = "Student";

        public string ConfirmPassword { get; set; }

       
    }
}
