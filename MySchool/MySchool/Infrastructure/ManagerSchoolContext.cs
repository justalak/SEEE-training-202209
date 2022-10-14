using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySchool.Models;

namespace MySchool.Infrastructure
{
    public class ManagerSchoolContext : DbContext
    {
        public ManagerSchoolContext(DbContextOptions<ManagerSchoolContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
