using Microsoft.EntityFrameworkCore;
using MySchool.Models;

namespace MySchool.Infrastructure
{
    public class ManagerStudentContext : DbContext
    {
        public ManagerStudentContext(DbContextOptions<ManagerStudentContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
