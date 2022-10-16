using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using WebApplication6.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace WebApplication6.Infrastructure
{
    public class ManagerSchoolContext : DbContext
    {
        public ManagerSchoolContext(DbContextOptions<ManagerSchoolContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
    }
}
