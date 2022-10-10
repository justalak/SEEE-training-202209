using Microsoft.EntityFrameworkCore;
using MySchool.Models;

namespace MySchool.Infrastructure
{
    public class ManagerTeacherContext : DbContext
    {
        public ManagerTeacherContext(DbContextOptions<ManagerTeacherContext> options) : base(options)
        {
        }
        public DbSet<Teacher> Teachers { get; set; }
    }
}