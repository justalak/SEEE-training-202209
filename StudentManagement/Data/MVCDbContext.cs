using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.Domain;
using System.Security.Claims;

namespace StudentManagement.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Class> Class { get; set; }
    }
}

